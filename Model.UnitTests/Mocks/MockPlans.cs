using Model.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Model.UnitTests.Mocks
{
    public static class MockPlans
    {
        public static Plan GetPlan(string id)
        {
            if (id == Plan1().PlanId)
            {
                return Plan1();
            }
            return new Plan();
        }
        
        public static Plan Plan1()
        {
            return new Plan
            {
                PlanId = "plan-1",
                Status = DataTypes.Status.Created,
                CoachId = MockUsers.Coach().UserId,
                TraineeId = MockUsers.Trainee().UserId,
                WorkoutIds = new List<string> { MockWorkouts.Workout1().WorkoutId }
            };
        }
        public static Plan creationNullPlanId()
        {
            return new Plan
            {
                PlanId = null,
                Status = DataTypes.Status.Created,
                CoachId = MockUsers.Coach().UserId,
                TraineeId = MockUsers.Trainee().UserId,
                WorkoutIds = new List<string> { MockWorkouts.Workout1().WorkoutId }
            };
        }
        public static Plan creationWithId()
        {
            return new Plan
            {
                PlanId = "Spaghetti",
                Status = DataTypes.Status.Created,
                CoachId = MockUsers.Coach().UserId,
                TraineeId = MockUsers.Trainee().UserId,
                WorkoutIds = new List<string> { MockWorkouts.Workout1().WorkoutId }
            };
        }
        public static Plan creationWithoutCoach()
        {
            return new Plan
            {
                PlanId = "plan-1",
                Status = DataTypes.Status.Created,
                CoachId = null,
                TraineeId = MockUsers.Trainee().UserId,
                WorkoutIds = new List<string> { MockWorkouts.Workout1().WorkoutId }
            };
        }
    }
}
