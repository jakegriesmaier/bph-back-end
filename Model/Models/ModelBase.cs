using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Models
{
    public abstract class ModelBase
    {

        private readonly DataAccessLocatorBase _dataAccessLocator;

        #region Data Accessors
        protected internal UserDataAccessorBase UserDataAccessor => _dataAccessLocator.GetUserDataAccessor();
        //TODO: Additional Entity Accessors
    
        #endregion
        internal ModelBase(DataAccessLocatorBase dataAccessLocator)
        {
            _dataAccessLocator = dataAccessLocator;
        }
    }
}
