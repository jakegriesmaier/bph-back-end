using System;
using Microsoft.EntityFrameworkCore;
using Model.Exceptions;

namespace Persistence.DataExceptions
{
    public class ExceptionHandler
    {
        public static Exception HandleException(Exception e, string type, string action)
        {
            string userMessage = "";
            if (e is DbUpdateException)
            {
                userMessage = GenerateExceptionMessage(type, action, "There was an error while trying to action a type");
                throw new DatabaseException(e.Message, userMessage, e as DbUpdateException);
            }
            if (e is InvalidOperationException)
            {
                userMessage = GenerateExceptionMessage(type, action, "There was an error while trying to action a type");
                throw new DatabaseException(e.Message, userMessage, e as InvalidOperationException);
            }
            if (e is UserAuthenticationException)
            {
                userMessage = GenerateExceptionMessage(type, action, "There was an error while trying to action a type");
                throw new UserAuthenticationException(((UserAuthenticationException)e).DeveloperMessage, userMessage);
            }
            if (e is DuplicateDataException)
            {
                string message = ((DuplicateDataException)e).DeveloperMessage;
                throw new DuplicateDataException(message, message);
            }
            
            return e;

        }

        public static Exception HandleException(Exception e, string somethingtemp)
        {
            string userMessage = "";
           if (e is DbUpdateException)
            {
                throw new DatabaseException(e.Message, userMessage, e as DbUpdateException);
            }
            if (e is InvalidOperationException)
            {
                throw new DatabaseException(e.Message, userMessage, e as InvalidOperationException);
            }
            if (e is UserAuthenticationException)
            {
                throw new UserAuthenticationException(((UserAuthenticationException)e).DeveloperMessage, userMessage);
            }
           
            return e;

        }


        private static string GenerateExceptionMessage(string type, string action, string messageTemplate)
        {
            messageTemplate = messageTemplate.Replace("type", type);
            messageTemplate = messageTemplate.Replace("action", action);
            return messageTemplate;
        }
    }
}
