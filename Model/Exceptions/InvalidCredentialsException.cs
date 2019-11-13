using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model.Exceptions
{
    public class InvalidCredentialsException : CustomException
    {
        private const HttpStatusCode code = HttpStatusCode.Unauthorized;  

        public InvalidCredentialsException() : base() {
            this.StatusCode = code;
        }

        public InvalidCredentialsException(string message) : base(message) {
            this.StatusCode = code;
        }

        public InvalidCredentialsException(string message, Exception innerException) : base(message, innerException) {
            this.StatusCode = code;
        }
    }
}
