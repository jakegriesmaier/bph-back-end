using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Presentation.Controllers.CoachPresenter.InputData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers.CoachPresenter
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CoachController : BaseController
    {

        // POST api/Coach/CreatePlan
        [HttpPost("[action]")]
        public async Task CreatePlan([FromBody] Plan plan)
        {
            await CoachModel.CreatePlan(plan);
        }

        // GET api/Coach/GetPlan
        [HttpGet("[action]")]
        public async Task<Plan> GetPlan([FromBody] GetPlanInputData input)
        {
            return await CoachModel.GetPlan(input.PlanId);
        }


        [HttpPut("[action]")]
        public async Task<Plan> UpdatePlan([FromBody] Plan plan)
        {
            return await CoachModel.UpdatePlan(plan);
        }

        // POST api/Coach/CreateWorkout
        [HttpPost("[action]")]
        public async Task CreateWorkout([FromBody] CreateWorkoutInputData input)
        {
            await CoachModel.CreateWorkout(input.Workout, input.PlanId);
        }

        // GET api/Coach/GetWorkout
        [HttpGet("[action]")]
        public async Task<Workout> GetWorkout([FromBody] GetWorkoutInputData input)
        {
            return await CoachModel.GetWorkout(input.WorkoutId);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Plan>> GetPlans()
        {
            return await CoachModel.GetPlans();
        }

    }
}
