using System;
using System.Net;

namespace Model.Exceptions
{
    /// <summary>
    /// Exception thrown when the call tries to add data that already exists
    /// </summary>
    public class DuplicateDataException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.409;

        public DuplicateDataException() : base()
        {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public DuplicateDataException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public DuplicateDataException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
    }
}