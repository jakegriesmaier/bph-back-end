using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.DataAccess;
using Persistence;
using Persistence.EntityFramework;

namespace Presentation.Controllers
{
    public abstract class BaseController : ControllerBase
    {

        private DbContextOptions<BphContext> _options = new DbOptionBuilder().BuildOptions();

        // used for accessing database
        private DataAccessLocatorBase _dataAccessLocator;
        protected internal DataAccessLocatorBase DataAccessLocator => _dataAccessLocator ?? (new DataAccessLocator(_options));

    }
}