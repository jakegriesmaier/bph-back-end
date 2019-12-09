using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.DataAccess.BaseAccessors;
using Model.DataTypes;
using Model.Entities;
using Model.Exceptions;
using Model.Interfaces;
using Persistence.DataAccessObjects;
using Persistence.DataExceptions;
using Persistence.EntityFramework;
using Persistence.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            try
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
                    await _userManager.AddToRoleAsync(user, user.AccountType.ToString());
                    return user.Id;
                }

                var exceptionText = result.Errors.Aggregate("User Creation Failed - Identity Exception. Errors were: \n\r\n\r", (current, error) => current + (" - " + error + "\n\r"));
                throw new UserAuthenticationException(exceptionText, "");
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "user", "create");
            }
        }

        protected override async Task<string> LoginUserCore(string email, string password)
        {


            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);//change if want cookie to persist

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    return user.Id;
                }
            }
            if (result.IsLockedOut)
            {
                throw new UserAuthenticationException("User is locked out of account", "You seem to be locked out of your account... We cannot sign you in right now");
            }
            if (result.IsNotAllowed)
            {
                throw new UserAuthenticationException("Not implemented yet, but if it was, the user needs to confirm their email", "You must confirm your email first!");
            }
            if (result.RequiresTwoFactor)
            {
                throw new UserAuthenticationException("For some reason it's saying we need 2 factor auth", "Uh I guess you need 2fa which isn't supposed to be a thing right now");
            }
            throw new UserAuthenticationException("Invalid username or password", "Invalid Username or Password");
        }


        protected override async Task LogoutUserCore()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "user", "log out");
            }
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
                throw ExceptionHandler.HandleException(e, "current user", "get");
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
                throw ExceptionHandler.HandleException(e, "user", "update");
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
                return null;
            }
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "password", "update");
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
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "user", "get");
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
            catch (Exception e)
            {
                throw ExceptionHandler.HandleException(e, "trainees", "get");
            }
        }
    }
}
