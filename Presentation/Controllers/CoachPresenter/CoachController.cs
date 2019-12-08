using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DataTypes;
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
    [Authorize(Roles = "Coach")]
    public class CoachController : BaseController
    {

        // POST api/Coach/CreatePlan
        [HttpPost("[action]")]
        public async Task<CreatePlanOutputData> CreatePlan([FromBody] Plan plan)
        {
            var result = await CoachModel.CreatePlan(plan);
            return new CreatePlanOutputData { PlanId = result };
        }

        // GET api/Coach/GetPlan
        [HttpGet("[action]")]
        public async Task<Plan> GetPlan(string planId)
        {
            return await CoachModel.GetPlan(planId);
        }

        [HttpPut("[action]")]
        public async Task<Plan> UpdatePlan([FromBody] Plan plan)
        {
            return await CoachModel.UpdatePlan(plan);
        }

        // POST api/Coach/CreateWorkout
        [HttpPost("[action]")]
        public async Task<CreateWorkoutOutputData> CreateWorkout([FromBody] CreateWorkoutInputData input)
        {
            var result = await CoachModel.CreateWorkout(input.Workout, input.PlanId);
            return new CreateWorkoutOutputData { WorkoutId = result };
        }

        // GET api/Coach/GetWorkout
        [HttpGet("[action]")]
        public async Task<Workout> GetWorkout(string workoutId)
        {
            return await CoachModel.GetWorkout(workoutId);
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
        public async Task<IEnumerable<Workout>> GetWorkouts(string planId)
        {
            return await CoachModel.GetWorkouts(planId);
        }

        [HttpPost("[action]")]
        public async Task<CreateExerciseOutputData> CreateExercise([FromBody] CreateExerciseInputData input)
        {
            var result = await CoachModel.CreateExercise(input.Exercise,input.WorkoutId);
            return new CreateExerciseOutputData { ExerciseId = result };
        }

        [HttpGet("[action]")]
        public async Task<Exercise> GetExercise(string exerciseId)
        {
            return await CoachModel.GetExercise(exerciseId);
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
        public  async Task<IEnumerable<Exercise>> GetExercises(string workoutId)
        {
            return await CoachModel.GetExercises(workoutId);
        }

        [HttpPost("[action]")]
        public async Task<CreateSetOutputData> CreateSet([FromBody] CreateSetInputData input)
        {
            var result = await CoachModel.CreateSet(input.Set,input.ExerciseId);
            return new CreateSetOutputData { SetId = result };
        }

        [HttpGet("[action]")]
        public async Task<Set> GetSet(string setId)
        {
            return await CoachModel.GetSet(setId);
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
        public async Task<IEnumerable<Set>> GetSets(string exerciseId)
        {
            return await CoachModel.GetSets(exerciseId);
        }

        [HttpPost("[action]")]
        public async Task<CreateCommentOutputData> CreateComment([FromBody] CreateCommentInputData input)
        {
            var result = await CoachModel.CreateComment(input.Comment, input.OwnerId);
            return new CreateCommentOutputData { CommentId = result };
        }

        [HttpGet("[action]")]
        public async Task<Comment> GetComment(string commentId)
        {
            return await CoachModel.GetComment(commentId);
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
        public async Task<IEnumerable<Comment>> GetComments(string ownerId)
        {
            return await CoachModel.GetComments(ownerId);
        }

        [HttpGet("[action]")]
        public async Task<User> GetTrainee(string traineeId)
        {
            return await CoachModel.GetTrainee(traineeId);
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<User>> GetTrainees()
        {
            return await CoachModel.GetTrainees();
        }

        [HttpDelete("[action]")]
        public async Task<DeletePlanOutputData> DeletePlan([FromBody] DeletePlanInputData input)
        {
            var result = await CoachModel.DeletePlan(input.PlanId);
            return new DeletePlanOutputData { Deleted = result };
        }
    }
}
