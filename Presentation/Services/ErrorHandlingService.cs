using Microsoft.AspNetCore.Http;
using Model.Exceptions;
using Newtonsoft.Json;
using Persistence.DataExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Presentation.Services
{
    public class ErrorHandlingService
    {

        private readonly RequestDelegate _next;

        public ErrorHandlingService(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = HttpStatusCode.InternalServerError; // 500 if unexpected
            var result = JsonConvert.SerializeObject(new { error = ex.Message });

            if (ex is CustomException)
            {
                statusCode = (ex as CustomException).StatusCode;
                result = JsonConvert.SerializeObject(new {
                    error = ex.Message,
                    developerMessage = (ex as CustomException).DeveloperMessage
                });
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }

    }
}
