using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.UserPresenter.InputData;

namespace Presentation.Controllers.UserPresenter
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserController : BaseController
    {
        //API CALLS FOR USER MODEL GO HERE
        // POST api/values
        [AllowAnonymous]
        [HttpPost]
        public async Task CreateUser([FromBody] CreateUserInputData input)
        {
            await UserModel.CreateUser(input.Email, input.Password);
        }

        [AllowAnonymous]
        [HttpPost]
        public void LoginUser([FromBody] LoginUserInputData input)
        {
             
        }
    }
}