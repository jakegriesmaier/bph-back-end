using System;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Model.Models.Validators
{
    public class CredentialsValidator
    {
        private static class PasswordRegex
        {
            public static Regex hasNumber = new Regex(@"[0-9]+");
            public static Regex hasNoWhiteSpace = new Regex(@"/^\S+$/");
            public static Regex hasUppercase = new Regex(@"[A-Z]+");
            public static Regex hasLowercase = new Regex(@"[a-z]+");
            public static Regex hasLength = new Regex(@".{8,15}");
            public static Regex hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");
        }

        public static bool ValidateCredentials(String email, String password)
        {
            return ValidateEmail(email) && ValidatePassword(password);
        }

        public static bool ValidateEmail(String email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (Exception e) when (e is ArgumentException | e is ArgumentNullException | e is FormatException)
            {
                return false;
            }
       
        }


        public static bool ValidatePassword(String password)
        {
            if (!MatchRegex(PasswordRegex.hasNumber, password))
            {
                return false;
            }
            else if (MatchRegex(PasswordRegex.hasNoWhiteSpace, password))
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
            else if (!MatchRegex(PasswordRegex.hasLength, password))
            {
                return false;
            }
            else if (!MatchRegex(PasswordRegex.hasSymbols, password))
            {
                return false;
            }
            return true;
        }
        private static bool MatchRegex(Regex regex, String toMatch)
        {
            return regex.Match(toMatch).Success;
        }
    }
}
