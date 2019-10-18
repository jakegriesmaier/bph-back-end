using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DataAccess;
using Persistence;

namespace Presentation.Controllers
{
    public abstract class BaseController : ControllerBase
    {

        // used for accessing database
        private DataAccessLocatorBase _dataAccessLocator;
        protected internal DataAccessLocatorBase DataAccessLocator => _dataAccessLocator ?? (new DataAccessLocator());

    }
}