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

        public async Task<string> CreateUser(string email, string password)
        {
            if (!CredentialsValidator.ValidateCredentials(email, password))
            {
                throw new InvalidParameterFormatException(ExceptionMessages.INVALID_CREATE_ACCOUNT_PARAMS,
                    ExceptionMessages.INVALID_CREATE_ACCOUNT_PARAMS_USER_FRIENDLY);
            }
        
            return await UserDataAccessor.CreateUser(email, password);
        }

        public async Task<string> LoginUser(string email, string password)
        {
            if (!CredentialsValidator.ValidateCredentials(email, password))
            {
                throw new InvalidParameterFormatException(ExceptionMessages.INVALID_LOG_IN_PARAMS, 
                    ExceptionMessages.INVALID_LOG_IN_PARAMS_USER_FRIENDLY);
            }
            return await UserDataAccessor.LoginUser(email, password);
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
            if (!UserValidator.ValidateUpdateUser(user))
            {
                throw new InsufficientInformationException(ExceptionMessages.INVALID_UPDATE_USER_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_USER_PARAMS_USER_FRIENDLY);
            }
            return await UserDataAccessor.UpdateUser(user);

        }

        public async Task<User> UpdatePassword(String oldPassword, String newPassword)
        {
            User user = await GetCurrentUser();
            
            if (!CredentialsValidator.ValidateCredentials(user.Email, newPassword))
            {
                throw new InvalidParameterFormatException(ExceptionMessages.INVALID_UPDATE_PASSWORD_PARAMS,
                    ExceptionMessages.INVALID_UPDATE_PASSWORD_PARAMS_USER_FRIENDLY);
            }
            return await UserDataAccessor.UpdatePassword(user, oldPassword, newPassword);
        }
    }
}
