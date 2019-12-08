using System;
using System.Net;
using Model.Exceptions;

namespace Persistence.DataExceptions
{
    public class ParentDoesNotExistException : CustomException
    {

        /// <summary>
        /// Exception thrown when the parent of a certain entity does not exit 
        /// </summary>
     
        private const HttpStatusCode code = HttpStatusCode.Unauthorized;

        public ParentDoesNotExistException() : base()
        {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public ParentDoesNotExistException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public ParentDoesNotExistException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
        }
    
}
