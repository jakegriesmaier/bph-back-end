using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers.CoachPresenter.InputData
{
    public class CreateWorkoutInputData
    {
        public string planId { get; set; }
        public Workout workout { get; set; }
    }
}
