using Model.DataAccess;
using Model.DataAccess.BaseAccessors;
using Model.UnitTests.Mocks.MockDataAccessors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.UnitTests.Mocks
{
    public class MockDataAccessLocator : DataAccessLocatorBase
    {
        protected override UserDataAccessorBase GetUserDataAccessorCore()
        {
            return new MockUserDataAccessor();
        }

        protected override PlanDataAccessorBase GetPlanDataAccessorCore()
        {
            return new MockPlanDataAccessor();
        }

        protected override WorkoutDataAccessorBase GetWorkoutDataAccessorCore()
        {
            return new MockWorkoutDataAccessor();
        }

        protected override ExerciseDataAccessorBase GetExerciseDataAccessorBaseCore()
        {
            return new MockExerciseDataAccessor();
        }

        protected override SetDataAccessorBase GetSetDataAccessorCore()
        {
            return new MockSetDataAccessor();
        }

        protected override CommentDataAccessorBase GetCommentDataAccessorCore()
        {
            return new MockCommentDataAccessor();
        }
    }
}
