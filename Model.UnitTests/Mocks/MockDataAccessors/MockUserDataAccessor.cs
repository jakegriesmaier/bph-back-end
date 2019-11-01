using Model.DataAccess.BaseAccessors;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockUserDataAccessor : UserDataAccessorBase
    {
        protected override async Task CreateUserCore(string email, string password)
        {
            await Task.CompletedTask;
        }

        protected override async Task<User> GetCurrentUserCore()
        {
            var user = MockUsers.Coach(); 
            return await Task.FromResult(user);
        }

        protected override async Task LoginUserCore(string email, string password)
        {
            await Task.CompletedTask;
        }

        protected override async Task LogoutUserCore()
        {
            await Task.CompletedTask;
        }

        protected override async Task<User> UpdateUserCore(User user)
        {
            return await Task.FromResult(user);
        }
    }
}
