using Model.DataAccess;
using Model.Models.Validators;
using System;
using System.Collections.Generic;
using System.Web;
using System.Threading.Tasks;
using System.Net.Http;
using Model.Entities;
using Model.Exceptions;

namespace Model.Models
{
    public sealed class UserModel : ModelBase
    {

        // Required Constructor in order to implement ModelBase
        public UserModel(DataAccessLocatorBase dataAccessLocator) : base(dataAccessLocator) { }

        public async Task CreateUser(string email, string password)
        {
            if (!CredentialsValidator.ValidateCredentials(email, password))
            {
                throw new InvalidCredentialsException("The credentials entered do not match the required specifications.");
            }
        
            await UserDataAccessor.CreateUser(email, password);
        }

        public async Task LoginUser(string email, string password)
        {
            if (!CredentialsValidator.ValidateCredentials(email, password))
            {
                throw new HttpRequestException("Invalid Credentials");
            }
            await UserDataAccessor.LoginUser(email, password);
        }

        public async Task LogoutUser()
        {
            await UserDataAccessor.LogoutUser();
        }

        public async Task<User> GetCurrentUser()
        {
            return await UserDataAccessor.GetCurrentUser();
        }

        public async Task<User> UpdateUser(User user)
        {
            if (!UserChangeValidator.ValidateUpdateUser(user))
            {
                throw new HttpRequestException("Updated User without Email or Password");
            }
            return await UserDataAccessor.UpdateUser(user);

        }

        public async Task<User> UpdatePassword(String oldPassword, String newPassword)
        {
            User user = await GetCurrentUser();
            
            if (!CredentialsValidator.ValidateCredentials(user.Email, newPassword))
            {
                throw new HttpRequestException("New Password is Invalid");
            }
            return await UserDataAccessor.UpdatePassword(user, oldPassword, newPassword);
        }
    }
}
