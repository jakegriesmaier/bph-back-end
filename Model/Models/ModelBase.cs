using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public abstract class ModelBase
    {

        protected readonly DataAccessLocatorBase _dataAccessLocator;

        #region Data Accessors
        protected UserDataAccessorBase _userDataAccessor => _dataAccessLocator.GetUserDataAccessor();
        #endregion

        internal ModelBase(DataAccessLocatorBase dataAccessLocator)
        {
            _dataAccessLocator = dataAccessLocator;
        }
    }
}
