
using BookStoreApp.API.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace BookStoreApp.API.Middleware
{
    public class ExceptionMiddleware
    {
        // _next represents operation about to occur
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        // when request comes in, _next embodies that request
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this._next = next;
            this._logger = logger;
        }

        // global try catch aroudn every request in the app
        // if the request throws exception we can handle it via
        // the HandleExceptionAsync() method
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong processing: {context.Request.Path}.");
                await HandleExceptionAsync(context, ex);

            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            //declare it as json, and as a InternalServerError
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;

            var errorDetails = new ErrorDetails
            {
                ErrorType = "Failure",
                ErrorMessage = ex.Message
            };

            // switch against exception object
            switch (ex)
            {
                // convert InternalServerError to NotFound
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not found.";
                    break;

                case BadRequestException badRequestException:
                    statusCode = HttpStatusCode.BadRequest;
                    errorDetails.ErrorType = "Bad request.";
                    break;

                default:
                    break;
            }
            // convert error details object to json string
            // respond with status code and contents of object
            string response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(response);
        }
    }
}
