using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model.Exceptions
{
    /// <summary>
    /// Exception that is thrown when the input data dos not meet the required format
    /// (Use for any calls that check the format of the input data, such as email and password)
    /// </summary>
    public class InvalidParameterFormatException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.UnprocessableEntity;  

        public InvalidParameterFormatException() : base() {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public InvalidParameterFormatException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public InvalidParameterFormatException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException) {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
    }
}
