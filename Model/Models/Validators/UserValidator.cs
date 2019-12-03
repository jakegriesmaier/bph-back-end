using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class UserValidator
    {

        public static bool ValidateGetUser(string userId)
        {
            if (userId == null)
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateUser(User user)
        {
   
            if (user.Email == null || user.UserId == null)
            {
                return false;
            }
            return true;
        }
    }
}
