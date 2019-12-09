using System;
using System.Net;

namespace Model.Exceptions
{
    /// <summary>
    /// Exception that is thrown when the UserManager is unable to perform an action for
    /// whatever reason
    /// </summary>
    public class UserAuthenticationException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.Unauthorized;

        public UserAuthenticationException() : base()
        {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public UserAuthenticationException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public UserAuthenticationException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
    }
}
