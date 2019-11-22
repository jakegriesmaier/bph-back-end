using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers.TraineePresenter.InputData
{
    public class CreateCommentInputData
    {
        public Comment Comment { get; set; }
        public string OwnerId { get; set; }
    }
}

