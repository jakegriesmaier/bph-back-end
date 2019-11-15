using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace Model.DataAccess.BaseAccessors
{
    public abstract class UserDataAccessorBase
    {
        public async Task<string> CreateUser(string email, string password)
        {
            return await CreateUserCore(email, password);
        }

        public async Task<string> LoginUser(string email, string password)
        {
            return await LoginUserCore(email, password);
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

        public async Task<User> GetUser(string userId)
        {
            return await GetUserCore(userId);
        }

        #region necessary implementations
        protected abstract Task<string> CreateUserCore(string email, string password);
        protected abstract Task<string> LoginUserCore(string email, string password);
        protected abstract Task LogoutUserCore();
        protected abstract Task<User> GetCurrentUserCore();
        protected abstract Task<User> UpdateUserCore(User user);
        protected abstract Task<User> UpdatePasswordCore(User user, string oldPassword, string newPassword);
        protected abstract Task<User> GetUserCore(string userId);
        #endregion

    }

}
