using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using learndotnetfast_web_services.Common.Exceptions.Custom;

namespace learndotnetfast_web_services.Common.Exceptions.Handlers
{
    public class ApiExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var response = new Dictionary<string, object>();
            int statusCode;

            if (context.Exception is ResourceNotFoundException)
            {
                response["error"] = "Resource Not Found";
                response["message"] = context.Exception.Message;
                statusCode = 404; // HttpStatusCode.NotFound
            }
            else if (context.Exception is DuplicateResourceException)
            {
                response["error"] = "Resource Already Exists";
                response["message"] = context.Exception.Message;
                statusCode = 409; // HttpStatusCode.Conflict
            }
            else
            {
                response["error"] = "Internal Server Error";
                response["message"] = "An unexpected error occurred.";
                statusCode = 500; // HttpStatusCode.InternalServerError
            }

            // Create an ObjectResult and set it as the context result
            context.Result = new ObjectResult(response)
            {
                StatusCode = statusCode
            };

            // Mark the exception as handled
            context.ExceptionHandled = true;
        }
    }
}
