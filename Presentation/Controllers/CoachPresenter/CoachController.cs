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

        [HttpPost("[action]")]
        public async Task CreatePlan([FromBody] Plan plan)
        {
            await CoachModel.CreatePlan(plan);
        }

        [HttpGet("[action]/{planId}")]
        public async Task<Plan> GetPlan(string planId)
        {
            return await CoachModel.GetPlan(planId);
        }

        [HttpPost("[action]")]
        public async Task CreateWorkout([FromBody] CreateWorkoutInputData input)
        {
            await CoachModel.CreateWorkout(input.workout, input.planId);
        }

        [HttpGet("[action]/{workoutId}")]
        public async Task<Workout> GetWorkout(string workoutId)
        {
            return await CoachModel.GetWorkout(workoutId);
        }

    }
}
