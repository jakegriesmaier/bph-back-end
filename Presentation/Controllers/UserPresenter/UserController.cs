using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Presentation.Controllers.UserPresenter.InputData;

namespace Presentation.Controllers.UserPresenter
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : BaseController
    {

        // POST api/User/CreateUser
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task CreateUser([FromBody] CreateUserInputData input)
        {
            await UserModel.CreateUser(input.Email, input.Password);
        }

        // POST api/User/LoginUser
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task LoginUser([FromBody] LoginUserInputData input)
        {
            await UserModel.LoginUser(input.Email, input.Password);
        }

        // POST api/User/LogoutUser
        [HttpPost("[action]")]
        public async Task LogoutUser()
        {
            await UserModel.LogoutUser();
        }

        // GET api/User/CheckSessionStatus
        [AllowAnonymous]
        [HttpGet("[action]")]
        public bool CheckSessionStatus()
        {
            if (User.Identity.IsAuthenticated)
            {
                return true;
            }
            return false;
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        public async Task<User> GetCurrentUser() {
            return await UserModel.GetCurrentUser();
        }

        [HttpPut("[action]")]
        public async Task<User> UpdateUser(User user)
        {
            return await UserModel.UpdateUser(user);
        }
    }
}