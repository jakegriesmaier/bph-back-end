using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using Persistence.DataAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class DataAccessLocator : DataAccessLocatorBase
    {
        public override UserDataAccessorBase GetUserDataAccessorCore()
        {
            return new UserDataAccessor();
        }
    }
}
