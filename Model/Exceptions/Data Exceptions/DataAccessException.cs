using System;
using System.Net;

namespace Model.Exceptions.DataExceptions
{
    /// <summary>
    /// Exception thrown when the call should not have been called from the 
    /// current user.
    /// </summary>
    public class DataAccessException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.Unauthorized;

        public DataAccessException() : base()
        {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public DataAccessException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public DataAccessException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
    }
}


using System;
using System.Net;

namespace Model.Exceptions.DataExceptions
{
    /// <summary>
    /// Exception thrown when a GET call has no associated data returned.
    /// </summary>
    public class DataDoesNotExistException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.NotFound;

        public DataDoesNotExistException() : base()
        {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public DataDoesNotExistException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public DataDoesNotExistException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
    }
}
