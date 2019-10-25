using Microsoft.EntityFrameworkCore;
using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using Persistence.DataAccessors;
using Persistence.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DataAccessLocator : DataAccessLocatorBase
    {

        private DbContextOptions<BphContext> _options;
        public DataAccessLocator(DbContextOptions<BphContext> options)
        {
            _options = options;
        }

        public override UserDataAccessorBase GetUserDataAccessorCore()
        {
            throw new NotImplementedException();
        }
    }
}
