using System;
using System.Text.RegularExpressions;

namespace Model.Models.Validators
{
    public class CredentialsValidator
    {
        private static class PasswordRegex
        {
            public static Regex hasNumber = new Regex(@"(?=.*\d)");
            public static Regex hasNoWhiteSpace = new Regex(@"(?!.*\s)");
            public static Regex hasUppercase = new Regex(@"(?=.*[A-Z])");
            public static Regex hasLowercase = new Regex(@"(?=.*[a-z])$");
            public static Regex hasLength = new Regex(@"(?=^.{8,15}$)");
        }


        public static bool ValidatePassword(String password)
        {
            if (!MatchRegex(PasswordRegex.hasNumber, password)) {
                return false;
            }
            else if (!MatchRegex(PasswordRegex.hasNoWhiteSpace, password))
            { 
                return false;
            }
            else if (!MatchRegex(PasswordRegex.hasUppercase, password))
            {
                return false;
            }
            else if (!MatchRegex(PasswordRegex.hasLowercase, password))
            {
                return false;
            }
            else if (!MatchRegex(PasswordRegex.hasLength, password)) {
                return false;
            }
            return true;
        }
        private static bool MatchRegex(Regex regex, String toMatch) {
            return regex.Match(toMatch).Success;
        }
    }
}
