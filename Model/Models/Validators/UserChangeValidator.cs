using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class UserChangeValidator
    {
       
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
