using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using Model.Interfaces;
using Persistence.DataAccessObjects;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DataAccessors
{
    public class UserDataAccessor : UserDataAccessorBase
    {

        private ICurrentUserService _currentUserService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private BphContext _context;
    
        public UserDataAccessor(ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, BphContext context)
        {
            _currentUserService = currentUserService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        protected override async Task<string> CreateUserCore(string email, string password)
        {

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var privateNote = new PrivateNoteDAO();
            user.PrivateNote = privateNote;

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                privateNote.UserId = user.Id;
                _context.Entry(privateNote).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await _userManager.AddToRoleAsync(user,user.AccountType.ToString());
                return user.Id;
            }

            //TODO: Jake S make custom
            throw new Exception("Failed to create user.");
        }

        protected override async Task<string> LoginUserCore(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);//change if want cookie to persist
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if(user != null)
                {
                    return user.Id;
                }
            }

            throw new Exception("Failed to log in user.");
        }

        protected override async Task LogoutUserCore()
        {
            await _signInManager.SignOutAsync();
        }

        protected override async Task<User> GetCurrentUserCore()
        {
            try
            {
                var userId = _currentUserService.UserId;
                var applicationUser = await _userManager.FindByIdAsync(userId);
                applicationUser.PrivateNote = await _context.PrivateNotes.FirstAsync(n => n.UserId == userId);
                return Mapper.map(applicationUser);
        
            }
            catch (Exception e)
            {
                throw new Exception("Error at getCurrentUserCore", e);
            }                    

        }

        protected override async Task<User> UpdateUserCore(User user)
        {
            try
            {
                var applicationUser = await _userManager.FindByIdAsync(_currentUserService.UserId);

                applicationUser.Email = user.Email;
                applicationUser.FirstName = user.FirstName;
                applicationUser.LastName = user.LastName;
                applicationUser.Id = user.UserId;
                applicationUser.Height = user.Height;
                applicationUser.Weight = user.Weight;
                applicationUser.AccountType = user.AccountType;
                await _userManager.UpdateAsync(applicationUser);
                applicationUser.PrivateNote = await _context.PrivateNotes.FirstAsync(n => n.UserId == applicationUser.Id);
                return Mapper.map(applicationUser);
            }
            catch (Exception e)
            {
                throw new Exception("Error at UpdateUserCore", e);
            }
        }

        protected override async Task<User> UpdatePasswordCore(User user, string oldPassword, string newPassword)
        {
            try
            {
                var applicationUser = await _userManager.FindByIdAsync(user.UserId);
                var result = await _userManager.ChangePasswordAsync(applicationUser, oldPassword, newPassword);
                if (result.Succeeded)
                {
                    applicationUser.PrivateNote = await _context.PrivateNotes.FirstAsync(n => n.UserId == applicationUser.Id);
                    return Mapper.map(applicationUser);
                }
                throw new Exception("Failed to Update Password");
            }
            catch (Exception e)
            {
                throw new Exception("Error at UpdatePasswordCore", e);
            }
        }

        protected override async Task<User> GetUserCore(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                user.PrivateNote = await _context.PrivateNotes.FirstAsync(n => n.UserId == userId);
                return Mapper.map(user);
            }
            catch
            {
                throw;
            }
        }

        protected override async Task<IEnumerable<User>> GetTraineesCore()
        {
            try
            {
                var trainees = await _userManager.GetUsersInRoleAsync(AccountType.Trainee.ToString());
                trainees.ToList().ForEach(t => t.PrivateNote = _context.PrivateNotes.First(n => n.UserId == t.Id));
                return trainees.Select(t => Mapper.map(t)).ToList();
            }
            catch
            {
                throw;
            }
        }
    }
}
