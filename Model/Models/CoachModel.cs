using Model.DataAccess;
using Model.Entities;
using Model.Models.Validators;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            plan.Coach = await UserDataAccessor.GetCurrentUser();
            plan.Status = plan.Trainee == null ? DataTypes.Status.Draft : DataTypes.Status.Created;
            if (!PlanValidator.ValidateCreatePlan(plan))
            {
                throw new HttpRequestException("Failed to create plan");
            }
            await PlanDataAccessor.CreatePlan(plan);
        }

        public async Task<Plan> GetPlan(string planId)
        {
            if (!PlanValidator.ValidateGetPlan(planId))
            {
                throw new HttpRequestException("Failed to get plan");
            }
            return await PlanDataAccessor.GetPlan(planId);
        }

        public async Task<Plan> UpdatePlan(Plan plan)
        {
            if (!PlanValidator.ValidateUpdatePlan(plan))
            {
                throw new HttpRequestException("Failed to update plan (improper plan)");
            }
            return await PlanDataAccessor.UpdatePlan(plan);
        }

        public async Task CreateWorkout(Workout workout, string planId)
        {
            workout.Status = DataTypes.Status.Created;
            if (!WorkoutValidator.ValidateCreateWorkout(workout, planId))
            {
                throw new HttpRequestException("Failed to create workout");
            }
            await WorkoutDataAccessor.CreateWorkout(workout, planId);
        }

        public async Task<Workout> GetWorkout(string workoutId)
        { 
            if (!WorkoutValidator.ValidateGetWorkout(workoutId))
            {
                throw new HttpRequestException("Failed to get workout");
            }
            return await WorkoutDataAccessor.GetWorkout(workoutId);
        }

    }
}
