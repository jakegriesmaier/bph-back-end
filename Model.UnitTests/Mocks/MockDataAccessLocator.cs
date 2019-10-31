using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Mocks
{
    public class MockDataAccessLocator : DataAccessLocatorBase
    {
        protected override UserDataAccessorBase GetUserDataAccessorCore()
        {
            throw new NotImplementedException();
        }

        protected override PlanDataAccessorBase GetPlanDataAccessorCore()
        {
            throw new NotImplementedException();
        }

        protected override WorkoutDataAccessorBase GetWorkoutDataAccessorCore()
        {
            throw new NotImplementedException();
        }
    }
}
