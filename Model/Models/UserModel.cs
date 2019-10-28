using Model.DataAccess;
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
            //TODO: jake s create email + password validator
            //#2 - if valid, create by calling dao
            await UserDataAccessor.CreateUser(email, password);
        }
        
    }
}
