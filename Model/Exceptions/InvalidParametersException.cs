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
        }

        public InvalidParametersException(string message) : base(message)
        {
            this.StatusCode = code;
        }

        public InvalidParametersException(string message, Exception innerException) : base(message, innerException)
        {
            this.StatusCode = code;
        }
    }
}
