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

        // GET api/Trainee/GetWorkouts
        [HttpGet("[action]")]
        public async Task<IEnumerable<Workout>> GetWorkouts([FromBody] GetWorkoutsInputData input)
        {
            return await TraineeModel.GetWorkouts(input.PlanId);
        }

        [HttpGet("[action]")]
        public async Task<Exercise> GetExercise([FromBody] GetExerciseInputData input)
        {
            return await TraineeModel.GetExercise(input.ExerciseId);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Exercise>> GetExercises([FromBody] GetExercisesInputData input)
        {
            return await TraineeModel.GetExercises(input.WorkoutId);
        }

        [HttpGet("[action]")]
        public async Task<Set> GetSet([FromBody] GetSetInputData input)
        {
            return await TraineeModel.GetSet(input.SetId);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Set>> GetSets([FromBody] GetSetsInputData input)
        {
            return await TraineeModel.GetSets(input.ExerciseId);
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

        [HttpPost("[action]")]
        public async Task<CreateCommentOutputData> CreateComment([FromBody] CreateCommentInputData input)
        {
            var result = await TraineeModel.CreateComment(input.Comment, input.OwnerId);
            return new CreateCommentOutputData { CommentId = result };
        }

        [HttpGet("[action]")]
        public async Task<Comment> GetComment([FromBody] GetCommentInputData input)
        {
            return await TraineeModel.GetComment(input.CommentId);
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
        public async Task<IEnumerable<Comment>> GetComments([FromBody] GetCommentsInputData input)
        {
            return await TraineeModel.GetComments(input.OwnerId);
        }

    }
}
