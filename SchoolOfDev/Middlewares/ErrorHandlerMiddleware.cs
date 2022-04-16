using SchoolOfDev.Exceptions;
using System.Net;
using System.Text.Json;

namespace SchoolOfDev.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "aplication/json";

                response.StatusCode = error switch {
                    BadRequestException => (int) HttpStatusCode.BadRequest,
                    KeyNotFoundException => (int) HttpStatusCode.NotFound,
                    ForbiddenExcepetion => (int)HttpStatusCode.Forbidden,
                    _ => (int)HttpStatusCode.InternalServerError,
                };

                var result = JsonSerializer.Serialize(new {status = false, message = error?.Message});
                await response.WriteAsync(result);
            }
        }
    }
}
