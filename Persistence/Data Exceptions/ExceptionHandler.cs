using System;
using Microsoft.EntityFrameworkCore;
using Model.Exceptions;
using Model.Exceptions.DataExceptions;

namespace Persistence.DataExceptions
{
    public class ExceptionHandler
    {
        public void HandleException(Exception e, string userMessage)
        {
            if (e is DbUpdateException)
            { 
                throw new DatabaseException(userMessage, e.Message, e as DbUpdateException);
            }
            if (e is InvalidOperationException)
            {
                throw new DatabaseException(userMessage, e.Message, e as InvalidOperationException);

            }

            throw e;

        }
    }
}
