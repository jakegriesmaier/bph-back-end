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
        protected override async Task<string> CreateUserCore(string email, string password)
        {
            return await Task.FromResult(MockUsers.Coach().UserId);
        }

        protected override async Task<User> GetCurrentUserCore()
        {
            var user = MockUsers.Coach(); 
            return await Task.FromResult(user);
        }

        protected override async Task<string> LoginUserCore(string email, string password)
        {
            return await Task.FromResult(MockUsers.Coach().UserId);
        }

        protected override async Task LogoutUserCore()
        {
            await Task.CompletedTask;
        }

        protected override async Task<User> UpdateUserCore(User user)
        {
            return await Task.FromResult(user);
        }

        protected override async Task<User> UpdatePasswordCore(User user, string oldPassword, string newPassword)
        {
            return await Task.FromResult(user);
        }

        protected override async Task<User> GetUserCore(string userId)
        {
            return await Task.FromResult(MockUsers.Trainee());
        }

        protected override async Task<IEnumerable<User>> GetTraineesCore()
        {
            return await Task.FromResult(new List<User>{ MockUsers.Trainee() });
        }
    }
}
