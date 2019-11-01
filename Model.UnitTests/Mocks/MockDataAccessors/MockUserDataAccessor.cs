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
        // return fake calls to the database here for testing
        protected override Task CreateUserCore(string email, string password)
        {
            throw new NotImplementedException();
        }

        protected override Task<User> GetCurrentUserCore()
        {
            throw new NotImplementedException();
        }

        protected override Task LoginUserCore(string email, string password)
        {
            throw new NotImplementedException();
        }

        protected override Task LogoutUserCore()
        {
            throw new NotImplementedException();
        }

        protected override Task<User> UpdateUserCore(User user)
        {
            throw new NotImplementedException();
        }
    }
}
