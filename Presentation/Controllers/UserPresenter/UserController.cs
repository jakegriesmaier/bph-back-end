using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Presentation.Controllers.UserPresenter.InputData;
using Presentation.Controllers.UserPresenter.OutputData;

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
        public async Task<CreateUserOutputData> CreateUser([FromBody] CreateUserInputData input)
        {
            var result = await UserModel.CreateUser(input.Email, input.Password);
            return new CreateUserOutputData
            {
                UserId = result
            };
        }

        // POST api/User/LoginUser
        [AllowAnonymous]
        [HttpPost("[action]")]
        public async Task<LoginUserOutputData> LoginUser([FromBody] LoginUserInputData input)
        {
            var result = await UserModel.LoginUser(input.Email, input.Password);
            return new LoginUserOutputData
            {
                UserId = result
            };
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
        public CheckSessionStatusOutputData CheckSessionStatus()
        {
            return new CheckSessionStatusOutputData
            {
                ValidSession = CurrentUserService.IsAuthenticated,
                UserId = CurrentUserService.UserId
            };
        }

        [HttpGet("[action]")]
        public async Task<User> GetCurrentUser() {
            return await UserModel.GetCurrentUser();
        }

        [HttpPut("[action]")]
        public async Task<User> UpdateUser([FromBody] User user)
        {
            return await UserModel.UpdateUser(user);
        }

        [HttpPut("[action]")]
        public async Task<User> UpdatePassword(string oldPassword, string newPassword)
        {
            return await UserModel.UpdatePassword(oldPassword, newPassword);
        }
    }
}