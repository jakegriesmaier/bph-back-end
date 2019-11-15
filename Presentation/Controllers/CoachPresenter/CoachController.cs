using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Presentation.Controllers.CoachPresenter.InputData;
using Presentation.Controllers.CoachPresenter.OutputData;
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

        [HttpPut("[action]")]
        public async Task<Workout> UpdateWorkout([FromBody] Workout workout)
        {
            return await CoachModel.UpdateWorkout(workout);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Workout>> GetWorkouts([FromBody] GetWorkoutsInputData input)
        {
            return await CoachModel.GetWorkouts(input.PlanId);
        }

        [HttpPost("[action]")]
        public async Task<CreateExerciseOutputData> CreateExercise([FromBody] CreateExerciseInputData input)
        {
            var result = await CoachModel.CreateExercise(input.Exercise,input.WorkoutId);
            return new CreateExerciseOutputData { ExerciseId = result };
        }

        [HttpGet("[action]")]
        public async Task<Exercise> GetExercise([FromBody] GetExerciseInputData input)
        {
            return await CoachModel.GetExercise(input.ExerciseId);
        }

        [HttpPut("[action]")]
        public async Task<Exercise> UpdateExercise([FromBody] Exercise exercise)
        {
            return await CoachModel.UpdateExercise(exercise);
        }

        [HttpDelete("[action]")]
        public async Task<DeleteExerciseOutputData> DeleteExercise([FromBody] DeleteExerciseInputData input)
        {
            var result = await CoachModel.DeleteExercise(input.ExerciseId);
            return new DeleteExerciseOutputData { Deleted = result };
        }

        [HttpGet("[action]")]
        public  async Task<IEnumerable<Exercise>> GetExercises([FromBody] GetExercisesInputData input)
        {
            return await CoachModel.GetExercises(input.WorkoutId);
        }

        [HttpPost("[action]")]
        public async Task<CreateSetOutputData> CreateSet([FromBody] CreateSetInputData input)
        {
            var result = await CoachModel.CreateSet(input.Set,input.ExerciseId);
            return new CreateSetOutputData { SetId = result };
        }

        [HttpGet("[action]")]
        public async Task<Set> GetSet([FromBody] GetSetInputData input)
        {
            return await CoachModel.GetSet(input.SetId);
        }

        [HttpPut("[action]")]
        public async Task<Set> UpdateSet([FromBody] Set set)
        {
            return await CoachModel.UpdateSet(set);
        }

        [HttpDelete("[action]")]
        public async Task<DeleteSetOutputData> DeleteSet([FromBody] DeleteSetInputData input)
        {
            var result = await CoachModel.DeleteSet(input.SetId);
            return new DeleteSetOutputData { Deleted = result };
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Set>> GetSets([FromBody] GetSetsInputData input)
        {
            return await CoachModel.GetSets(input.ExerciseId);
        }

        [HttpPost("[action]")]
        public async Task<CreateCommentOutputData> CreateComment([FromBody] CreateCommentInputData input)
        {
            var result = await CoachModel.CreateComment(input.Comment, input.OwnerId);
            return new CreateCommentOutputData { CommentId = result };
        }

        [HttpGet("[action]")]
        public async Task<Comment> GetComment([FromBody] GetCommentInputData input)
        {
            return await CoachModel.GetComment(input.CommentId);
        }

        [HttpPut("[action]")]
        public async Task<Comment> UpdateComment([FromBody] Comment comment)
        {
            return await CoachModel.UpdateComment(comment);
        }

        [HttpDelete("[action]")]
        public async Task<DeleteCommentOutputData> DeleteComment([FromBody] DeleteCommentInputData input)
        {
            var result = await CoachModel.DeleteComment(input.CommentId);
            return new DeleteCommentOutputData { Deleted = result };
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Comment>> GetComments([FromBody] GetCommentsInputData input)
        {
            return await CoachModel.GetComments(input.OwnerId);
        }

        [HttpGet("[action]")]
        public async Task<User> GetTrainee([FromBody] GetTraineeInputData input)
        {
            return await CoachModel.GetTrainee(input.TraineeId);
        }
    }
}
