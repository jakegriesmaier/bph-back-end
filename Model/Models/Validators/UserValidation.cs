using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class UserValidation
    {
       
        public static bool ValidateUpdateUser(User oldUser, User newUser)
        {
            if (oldUser.Email == null || oldUser.UserId == null)
            {
                return false;
            }
            if (newUser.Email == null || newUser.UserId == null)
            {
                return false;
            }
            return true;
        }
    }
}
