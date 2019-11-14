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
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_PLAN_PARAMS);
            }
            return await PlanDataAccessor.GetPlan(planId);
        }

        public async Task<Workout> GetWorkout(string workoutId)
        {
            if (!WorkoutValidator.ValidateGetWorkout(workoutId))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_GET_WORKOUT_PARAMS);
            }
            return await WorkoutDataAccessor.GetWorkout(workoutId);
        }
    }
}
