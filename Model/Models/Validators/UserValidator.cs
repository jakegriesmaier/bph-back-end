using System;
using Model.Entities;

namespace Model.Models.Validators
{
    public class UserValidator
    {
        #region Validators
        public static bool ValidateGetUser(string userId)
        {
            if (!UserExists(userId))
            {
                return false;
            }
            return true;
        }

        public static bool ValidateUpdateUser(User user)
        {
            if (!UserExists(user))
            {
                return false;
            }
            if(!EmailExists(user))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region Helper Functions
        private static bool UserExists(string userId)
        {
            return (userId != null) && (userId != "");
        }
        private static bool UserExists(User user)
        {
            return (user.UserId != null) && (user.UserId != "");
        }
        private static bool EmailExists(User user)
        {
            return (user.Email != null) && (user.Email != "");
        }
        #endregion
    }
}
