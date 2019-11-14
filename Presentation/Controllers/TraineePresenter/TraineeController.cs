using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Models;
using Presentation.Controllers.TraineePresenter.InputData;
using System.Threading.Tasks;

namespace Presentation.Controllers.TraineePresenter
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

    }
}
