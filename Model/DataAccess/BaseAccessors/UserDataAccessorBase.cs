using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class UserDataAccessorBase
    {
        public async Task CreateUser(string email, string password)
        {
            await CreateUserCore(email, password);
        }

        public async Task LoginUser(string email, string password)
        {
            await LoginUserCore(email, password);
        }

        public async Task LogoutUser()
        {
            await LogoutUserCore();
        }

        public async Task<User> GetCurrentUser()
        {
            return await GetCurrentUserCore();
        }

        public async Task<User> UpdateUser(User user)
        {
            return await UpdateUserCore(user);
        }

        public async Task<User> UpdatePassword(User user, string oldPassword, string newPassword)
        {
            return await UpdatePasswordCore(user, oldPassword, newPassword);
        }

        #region necessary implementations
        protected abstract Task CreateUserCore(string email, string password);
        protected abstract Task LoginUserCore(string email, string password);
        protected abstract Task LogoutUserCore();
        protected abstract Task<User> GetCurrentUserCore();
        protected abstract Task<User> UpdateUserCore(User user);
        protected abstract Task<User> UpdatePasswordCore(User user, string oldPassword, string newPassword);
        #endregion

    }

}
