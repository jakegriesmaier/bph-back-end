using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Models;
using Presentation.Controllers.TraineePresenter.InputData;
using Presentation.Controllers.TraineePresenter.OutputData;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace Presentation.Controllers.TraineePresenter
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Trainee")]
    public class TraineeController : BaseController
    {
        // GET api/Trainee/GetPlan
        [HttpGet("[action]")]
        public async Task<Plan> GetPlan(string planId)
        {
            return await TraineeModel.GetPlan(planId);
        }

        [HttpPut("[action]")]
        public async Task<Plan> UpdatePlan([FromBody] Plan plan)
        {
            return await TraineeModel.UpdatePlan(plan);
        }

        // GET api/Trainee/GetWorkout
        [HttpGet("[action]")]
        public async Task<Workout> GetWorkout(string workoutId)
        {
            return await TraineeModel.GetWorkout(workoutId);
        }

        // GET api/Trainee/GetWorkouts
        [HttpGet("[action]")]
        public async Task<IEnumerable<Workout>> GetWorkouts(string planId)
        {
            return await TraineeModel.GetWorkouts(planId);
        }

        [HttpGet("[action]")]
        public async Task<Exercise> GetExercise(string exerciseId)
        {
            return await TraineeModel.GetExercise(exerciseId);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Exercise>> GetExercises(string workoutId)
        {
            return await TraineeModel.GetExercises(workoutId);
        }

        [HttpGet("[action]")]
        public async Task<Set> GetSet(string setId)
        {
            return await TraineeModel.GetSet(setId);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Set>> GetSets(string exerciseId)
        {
            return await TraineeModel.GetSets(exerciseId);
        }

        [HttpGet("[action]")]
        public async Task<GetCoachOutputData> GetCoach(string coachId)
        {
            var result = await TraineeModel.GetCoach(coachId);
            return new GetCoachOutputData {
                CoachId = result.UserId,
                FirstName = result.FirstName,
                LastName = result.LastName
            };
        }

        [HttpPost("[action]")]
        public async Task<CreateCommentOutputData> CreateComment([FromBody] CreateCommentInputData input)
        {
            var result = await TraineeModel.CreateComment(input.Comment, input.OwnerId);
            return new CreateCommentOutputData { CommentId = result };
        }

        [HttpGet("[action]")]
        public async Task<Comment> GetComment(string commentId)
        {
            return await TraineeModel.GetComment(commentId);
        }

        [HttpPut("[action]")]
        public async Task<Comment> UpdateComment([FromBody] Comment comment)
        {
            return await TraineeModel.UpdateComment(comment);
        }

        [HttpDelete("[action]")]
        public async Task<DeleteCommentOutputData> DeleteComment([FromBody] DeleteCommentInputData input)
        {
            var result = await TraineeModel.DeleteComment(input.CommentId);
            return new DeleteCommentOutputData { Deleted = result };
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Comment>> GetComments(string ownerId)
        {
            return await TraineeModel.GetComments(ownerId);
        }

    }
}
