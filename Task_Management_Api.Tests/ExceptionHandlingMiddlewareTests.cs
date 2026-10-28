
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using Task_Management_Api.Middleware;
using Xunit;

namespace Task_Management_Api.Tests
{
    public class ExceptionHandlingMiddlewareTests
    {
        [Fact]
        public async Task InvokeAsync_WhenExceptionOccurs_ReturnsInternalServerError()
        {
            // Arrange
            RequestDelegate next = (context) =>
                throw new Exception("Something went wrong");

            var logger = LoggerFactory
                .Create(builder => { })
                .CreateLogger<ExceptionHandlingMiddleware>();

            var middleware = new ExceptionHandlingMiddleware(
                next,
                logger);

            var context = new DefaultHttpContext();
            context.Request.Path = "/api/tasks";
            context.Response.Body = new MemoryStream();

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.Equal(
                StatusCodes.Status500InternalServerError,
                context.Response.StatusCode);

            Assert.Equal(
                "application/json",
                context.Response.ContentType);

            context.Response.Body.Position = 0;

            using var reader = new StreamReader(context.Response.Body);
            var responseBody = await reader.ReadToEndAsync();

            using var json = JsonDocument.Parse(responseBody);
            var root = json.RootElement;

            Assert.Equal(
                500,
                root.GetProperty("status").GetInt32());

            Assert.Equal(
                "Internal Server Error",
                root.GetProperty("error").GetString());

            Assert.Equal(
                "An unexpected error occurred.",
                root.GetProperty("message").GetString());

            Assert.Equal(
                "/api/tasks",
                root.GetProperty("path").GetString());

            Assert.True(root.TryGetProperty("timestamp", out _));
        }
    }
}
