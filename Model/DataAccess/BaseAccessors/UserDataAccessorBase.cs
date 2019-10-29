﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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


        #region necessary implementations
        protected abstract Task CreateUserCore(string email, string password);
        protected abstract Task LoginUserCore(string email, string password);
        protected abstract Task LogoutUserCore();
        #endregion

    }

}
