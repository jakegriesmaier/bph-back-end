using Model.DataAccess;
using Model.Models.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
                throw new Exception("Invalid Credentials");
            }
        
            await UserDataAccessor.CreateUser(email, password);
        }

        public async Task LoginUser(string email, string password)
        {
            if (!CredentialsValidator.ValidateCredentials(email, password))
            {
                throw new Exception("Invalid Credentials");
            }
            await UserDataAccessor.LoginUser(email, password);
        }

        public async Task LogoutUser()
        {
            await UserDataAccessor.LogoutUser();
        }
        
    }
}
