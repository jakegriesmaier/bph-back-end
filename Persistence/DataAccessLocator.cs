using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using Model.Interfaces;
using Persistence.DataAccessors;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DataAccessLocator : DataAccessLocatorBase
    {

        private ICurrentUserService _currentUserService;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private BphContext _context;

        //TODO fix references, and move ICurrentUserService to Model
        public DataAccessLocator(ICurrentUserService currentUserService, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _currentUserService = currentUserService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = new DbContextBuilder().BuildContext();
        }

        public override UserDataAccessorBase GetUserDataAccessorCore()
        {
            return new UserDataAccessor(_currentUserService, _userManager, _signInManager, _context);
        }
    }
}
