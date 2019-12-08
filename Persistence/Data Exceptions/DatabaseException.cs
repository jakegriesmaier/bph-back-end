using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using Model.Exceptions;

namespace Persistence.DataExceptions
{
    /// <summary>
    /// Exception thrown as a generic DatabaseException. This contains its own
    /// inner exceptions, but makes it easier to show a user stuff.
    /// current user.
    /// </summary>
    public class DatabaseException : CustomException
    {

        private const HttpStatusCode code = HttpStatusCode.BadRequest;

        public DatabaseException() : base()
        {
            this.StatusCode = code;
            this.DeveloperMessage = "";
        }

        public DatabaseException(string devMessage, string message) : base(devMessage, message)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        public DatabaseException(string devMessage, string message, Exception innerException) : base(devMessage, message, innerException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        /*
         * SaveChangesAsync Handler
         */
        public DatabaseException(string devMessage, string message, DbUpdateException dbUpdateException) : base(devMessage, message, dbUpdateException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }

        /*
         * FindAsync Handler
         */
        public DatabaseException(string devMessage, string message, InvalidOperationException invalidOperationException) : base(devMessage, message, invalidOperationException)
        {
            this.StatusCode = code;
            this.DeveloperMessage = devMessage;
        }
    }
}
