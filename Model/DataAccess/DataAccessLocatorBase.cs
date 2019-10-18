using Model.DataAccess.BaseAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.DataAccess
{
    public abstract class DataAccessLocatorBase
    {
        public UserDataAccessorBase GetUserDataAccessor()
        {
            return GetUserDataAccessorCore();
        }



        #region Required Implementations
        public abstract UserDataAccessorBase GetUserDataAccessorCore();
        #endregion
    }
}
