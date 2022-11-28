using System.Net;
using System.Text.Json;

namespace theCakeShop.ApplicationLayer.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlerMiddleware> _logger;

        public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
        {
            _logger = logger;
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
                _logger.LogError(ex.Message);
                _logger.LogError(ex, ex.Message);

                var response = context.Response;
                response.ContentType = "application/json";

                response.StatusCode = GetStatusCode(ex);

                var errorMessage = JsonSerializer.Serialize(new {message = ex.Message});

                if(response.StatusCode == 500)
                    await response.WriteAsync(JsonSerializer.Serialize(new { message = "An error occurred" }));

                await response.WriteAsync(errorMessage);

            }
        }

        public int GetStatusCode(Exception error)
        {
            int statuscode = 500;
            switch (error)
            {
                case UnauthorizedAccessException:
                    statuscode = (int)HttpStatusCode.Forbidden;
                    break;
                case KeyNotFoundException:
                    statuscode = (int)HttpStatusCode.NotFound;
                    break;
                case ApplicationException:
                    statuscode = (int)HttpStatusCode.BadRequest;
                    break;
                case Exception:
                    statuscode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    statuscode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            return statuscode;
        }

    }
}
