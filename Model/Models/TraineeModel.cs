using System.Threading.Tasks;
using Model.DataAccess;
using Model.Entities;
using Model.Exceptions;
using Model.Models.Validators;

namespace Model.Models
{
    public class TraineeModel : ModelBase
    {
        public TraineeModel(DataAccessLocatorBase dataAccessLocator) : base(dataAccessLocator)
        {
        }

        public async Task<Plan> GetPlan(string planId)
        {
            if (!PlanValidator.ValidateGetPlan(planId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_PLAN_PARAMS, ExceptionMessages.INVALID_GET_PLAN_PARAMS_USER_FRIENDLY);
            }
            return await PlanDataAccessor.GetPlan(planId);
        }

        public async Task<Plan> UpdatePlan(Plan plan)
        {
            if (!PlanValidator.ValidateUpdatePlan(plan))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_PLAN_PARAMS, ExceptionMessages.INVALID_UPDATE_PLAN_PARAMS_USER_FRIENDLY);
            }
            return await PlanDataAccessor.UpdatePlan(plan);
        }

        public async Task<Workout> GetWorkout(string workoutId)
        {
            if (!WorkoutValidator.ValidateGetWorkout(workoutId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_WORKOUT_PARAMS, ExceptionMessages.INVALID_GET_WORKOUT_PARAMS_USER_FRIENDLY);
            }
            return await WorkoutDataAccessor.GetWorkout(workoutId);
        }
    }
}
