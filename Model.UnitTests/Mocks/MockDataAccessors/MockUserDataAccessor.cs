using Model.DataAccess.BaseAccessors;
using Model.Models.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitTests.Mocks.MockDataAccessors
{
    public class MockUserDataAccessor : UserDataAccessorBase
    {
        // return fake calls to the database here for testing
        protected override async Task CreateUserCore(string email, string password)
        {
            return;
        }

        protected override async Task LoginUserCore(string email, string password)
        { 
            return;
        }

        protected override async Task LogoutUserCore()
        {
            return;
        }
    }
}
