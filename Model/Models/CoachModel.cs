using Model.DataAccess;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public sealed class CoachModel : ModelBase
    {

        //Required Constructor in order to implement ModelBase
        public CoachModel(DataAccessLocatorBase dataAccessLocator) : base(dataAccessLocator) { }

        public async Task CreatePlan(Plan plan)
        {
            //TODO ADD COACH TO PLAN BEFORE VALIDATION (CURRENT USER)
            //VALIDATE
            await PlanDataAccessor.CreatePlan(plan);
        }

        public async Task<Plan> GetPlan(string planId)
        {
            //VALIDATE
            return await PlanDataAccessor.GetPlan(planId);
        }

        public async Task CreateWorkout(Workout workout, string planId)
        {
            //VALIDATE 
            await WorkoutDataAccessor.CreateWorkout(workout, planId);
        }

        public async Task<Workout> GetWorkout(string workoutId)
        {
            //VALIDATE
            return await WorkoutDataAccessor.GetWorkout(workoutId);
        }

    }
}
