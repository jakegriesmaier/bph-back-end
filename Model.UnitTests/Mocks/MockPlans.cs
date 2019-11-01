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
            if(id == Plan1().PlanId)
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
                Coach = MockUsers.Coach(),
                Trainee = MockUsers.Trainee(),
                Workouts = new List<Workout> { MockWorkouts.Workout1() },
            };
        }
    }
}
