﻿using Model.DataAccess;
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
        protected internal PlanDataAccessorBase PlanDataAccessor => _dataAccessLocator.GetPlanDataAccessor();
        protected internal WorkoutDataAccessorBase WorkoutDataAccessor => _dataAccessLocator.GetWorkoutDataAccessor();     
        #endregion

        internal ModelBase(DataAccessLocatorBase dataAccessLocator)
        {
            _dataAccessLocator = dataAccessLocator;
        }
    }
}
