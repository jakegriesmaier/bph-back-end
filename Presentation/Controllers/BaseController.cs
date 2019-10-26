using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataAccess;
using Persistence;
using Persistence.EntityFramework;
using Presentation.Services;
using Microsoft.Extensions.DependencyInjection;
using Model.Interfaces;

namespace Presentation.Controllers
{
    public abstract class BaseController : ControllerBase
    {

        // Service that gets data on the current user 
        private ICurrentUserService _currentUserService;
        private ICurrentUserService CurrentUserService => _currentUserService ?? (HttpContext.RequestServices.GetService<ICurrentUserService>());

        // Service used to add and delete users in the system
        private UserManager<ApplicationUser> _userManager;
        private UserManager<ApplicationUser> UserManager => _userManager ?? (HttpContext.RequestServices.GetService<UserManager<ApplicationUser>>());

        // Service used to sign in and sign out users in the system
        private SignInManager<ApplicationUser> _signInManager;
        private SignInManager<ApplicationUser> SignInManager => _signInManager ?? (HttpContext.RequestServices.GetService<SignInManager<ApplicationUser>>());

        // used for accessing database
        private DataAccessLocatorBase _dataAccessLocator;
        protected internal DataAccessLocatorBase DataAccessLocator => _dataAccessLocator ?? (new DataAccessLocator(CurrentUserService, UserManager, SignInManager));
    }
}