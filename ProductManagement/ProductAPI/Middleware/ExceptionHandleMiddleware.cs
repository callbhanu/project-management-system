//

using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace ProductAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Log the exception (you might want to use a logging framework like Serilog or log4net)

            // Create a custom error response
            var response = new ErrorResponse
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
                Message = "Internal Server Error..... Coming from Middleware...",
                Details = exception.Message // Include exception details if needed
            };

            // Set the response content type to JSON
            context.Response.ContentType = "application/json";

            // Set the response status code
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Serialize the error response object to JSON and write it to the response body
            return context.Response.WriteAsync(response.ToString());
        }

        private class ErrorResponse
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
            public string Details { get; set; }

            public override string ToString()
            {
                return Newtonsoft.Json.JsonConvert.SerializeObject(this);
            }
        }
    }
}

