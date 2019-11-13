using Microsoft.AspNetCore.Identity;
using Model.DataAccess.BaseAccessors;
using Model.Entities;
using Model.Interfaces;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
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

        protected override async Task CreateUserCore(string email, string password)
        {
            var user = new ApplicationUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
            {
                return;
            }

            //TODO: Jake S make custom
            throw new Exception("Failed to create user.");
        }

        protected override async Task LoginUserCore(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);//change if want cookie to persist
            if (result.Succeeded)
            {
                return;
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

                var applicationUser = Mapper.map(user);

                await _userManager.ChangePasswordAsync(applicationUser, oldPassword, newPassword); 
                return Mapper.map(applicationUser);
            }
            catch (Exception e)
            {
                throw new Exception("Errorat UpdatePasswordCore", e);
            }
        }
    }
}
