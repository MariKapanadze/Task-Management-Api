using System.Text.Json;

namespace Task_Management_Api.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "An unexpected error occurred.");

                context.Response.StatusCode =
                    StatusCodes.Status500InternalServerError;

                context.Response.ContentType = "application/json";

                var errorResponse = new
                {
                    timestamp = DateTime.UtcNow,
                    status = context.Response.StatusCode,
                    error = "Internal Server Error",
                    message = "An unexpected error occurred.",
                    path = context.Request.Path.Value
                };

                await context.Response.WriteAsync(
                    JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}
