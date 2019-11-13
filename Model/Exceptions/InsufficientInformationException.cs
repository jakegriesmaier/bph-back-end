using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model.Exceptions
{
    /// <summary>
    /// Exception thrown when the input data does not contain enough information to complete the call
    /// (use for GET calls that are missing the object id)
    /// </summary>
    public class InsufficientInformationException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.UnprocessableEntity;

        public InsufficientInformationException() : base()
        {
            this.StatusCode = code;
        }

        public InsufficientInformationException(string message) : base(message)
        {
            this.StatusCode = code;
        }

        public InsufficientInformationException(string message, Exception innerException) : base(message, innerException)
        {
            this.StatusCode = code;
        }
    }
}
