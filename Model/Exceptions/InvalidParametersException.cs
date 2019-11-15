using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model.Exceptions
{
    /// <summary>
    /// Exception that is thrown when the input data contains incorrect/invalid information
    /// (ie Create call that already contains the objects id)
    /// </summary>
    public class InvalidParametersException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.UnprocessableEntity;

        public InvalidParametersException() : base()
        {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public InvalidParametersException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public InvalidParametersException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
    }
}
