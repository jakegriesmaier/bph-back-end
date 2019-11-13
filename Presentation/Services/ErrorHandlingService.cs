﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
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

            if(ex is HttpRequestException)
            {
                statusCode = HttpStatusCode.Forbidden; // 403 sent for now, TODO add custom exceptions for better responses
            }

            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;
            return context.Response.WriteAsync(result);
        }

    }
}
