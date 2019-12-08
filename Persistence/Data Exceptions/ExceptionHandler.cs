using System;
using Microsoft.EntityFrameworkCore;
using Model.Exceptions;

namespace Persistence.DataExceptions
{
    public class ExceptionHandler
    {
        public CustomException HandleException(Exception e)
        {
            if (e is DbUpdateException)
            {
                return CustomException()
            }
        }
    }
}
