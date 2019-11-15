using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Model.Exceptions
{
    public class CustomException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public string DeveloperMessage { get; set; }

        public CustomException() : base() { }

        public CustomException(string devMessage, string message) : base(message) { }

        public CustomException(string devMessage, string message, Exception innerException) : base(message, innerException) { }

    }
}
