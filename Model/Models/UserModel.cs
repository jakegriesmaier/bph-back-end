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
                throw new InvalidParameterFormatException(ExceptionMessages.INVALID_CREATE_ACCOUNT_PARAMS);
            }
        
            await UserDataAccessor.CreateUser(email, password);
        }

        public async Task LoginUser(string email, string password)
        {
            if (!CredentialsValidator.ValidateCredentials(email, password))
            {
                throw new InvalidParameterFormatException(ExceptionMessages.INVALID_LOG_IN_PARAMS);
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
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_USER_PARAMS);
            }
            return await UserDataAccessor.UpdateUser(user);

        }

        public async Task<User> UpdatePassword(String oldPassword, String newPassword)
        {
            User user = await GetCurrentUser();
            
            if (!CredentialsValidator.ValidateCredentials(user.Email, newPassword))
            {
                throw new InvalidParameterFormatException(ExceptionMessages.INVALID_UPDATE_PASSWORD_PARAMS);
            }
            return await UserDataAccessor.UpdatePassword(user, oldPassword, newPassword);
        }
    }
}
