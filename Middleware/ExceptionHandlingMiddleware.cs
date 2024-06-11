namespace learndotnetfast_web_services.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; // You can be more specific about the status codes

            var result = JsonSerializer.Serialize(new
            {
                error = exception.Message,
                stackTrace = exception.StackTrace  // Remove stack trace in production for security
            });

            return context.Response.WriteAsync(result);
        }
    }

}
