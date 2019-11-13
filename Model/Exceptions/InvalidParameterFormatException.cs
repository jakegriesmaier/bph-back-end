﻿using System;
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
        }

        public InvalidParameterFormatException(string message) : base(message) {
            this.StatusCode = code;
        }

        public InvalidParameterFormatException(string message, Exception innerException) : base(message, innerException) {
            this.StatusCode = code;
        }
    }
}
