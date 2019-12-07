using Model.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers.TraineePresenter.InputData
{
    public class UpdateWorkoutStatusInputData
    {
        public string WorkoutId { get; set; }
        public Status Status { get; set; }
    }
}
