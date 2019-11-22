using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Models;
using Presentation.Controllers.TraineePresenter.InputData;
using Presentation.Controllers.TraineePresenter.OutputData;
using System.Threading.Tasks;

namespace Presentation.Controllers.TraineePresenter
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Trainee")]
    public class TraineeController : BaseController
    {
        // GET api/Trainee/GetPlan
        [HttpGet("[action]")]
        public async Task<Plan> GetPlan([FromBody] GetPlanInputData input)
        {
            return await TraineeModel.GetPlan(input.PlanId);
        }

        [HttpPut("[action]")]
        public async Task<Plan> UpdatePlan([FromBody] Plan plan)
        {
            return await TraineeModel.UpdatePlan(plan);
        }

        // GET api/Trainee/GetWorkout
        [HttpGet("[action]")]
        public async Task<Workout> GetWorkout([FromBody] GetWorkoutInputData input)
        {
            return await TraineeModel.GetWorkout(input.WorkoutId);
        }

        [HttpGet("[action]")]
        public async Task<GetCoachOutputData> GetCoach([FromBody] GetCoachInputData input)
        {
            var result = await TraineeModel.GetCoach(input.CoachId);
            return new GetCoachOutputData {
                CoachId = result.UserId,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
        }

    }
}
