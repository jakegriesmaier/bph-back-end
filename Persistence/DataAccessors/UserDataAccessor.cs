﻿using Microsoft.AspNetCore.Identity;
using Model.DataAccess.BaseAccessors;
using Model.Interfaces;
using Persistence.EntityFramework;
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
    }
}