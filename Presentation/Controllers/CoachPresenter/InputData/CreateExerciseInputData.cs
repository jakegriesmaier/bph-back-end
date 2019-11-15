using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers.CoachPresenter.InputData
{
    public class CreateExerciseInputData
    {
        public Exercise Exercise { get; set; }
        public string WorkoutId { get; set; }
    }
}
