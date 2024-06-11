using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace learndotnetfast_web_services.Common.Exceptions.Handlers
{
    public class DatabaseExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new Dictionary<string, string>();
            int statusCode = 500; // Default to internal server error

            if (context.Exception is DbUpdateException)//|| context.Exception is SqlException
            {
                response["error"] = "Database Operation Failed";
                response["message"] = context.Exception.Message;
                statusCode = 500; // HttpStatusCode.InternalServerError
            }
            else
            {
                // Let other exceptions pass through this filter
                return;
            }

            // Set the ObjectResult with status code and response
            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }
    }
}
