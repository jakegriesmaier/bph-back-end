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

        public PlanDataAccessorBase GetPlanDataAccessor()
        {
            return GetPlanDataAccessorCore();
        }

        public WorkoutDataAccessorBase GetWorkoutDataAccessor()
        {
            return GetWorkoutDataAccessorCore();
        }


        #region Required Implementations
        protected abstract UserDataAccessorBase GetUserDataAccessorCore();
        protected abstract PlanDataAccessorBase GetPlanDataAccessorCore();
        protected abstract WorkoutDataAccessorBase GetWorkoutDataAccessorCore();
        #endregion
    }
}
