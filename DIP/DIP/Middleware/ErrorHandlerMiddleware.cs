using DIP.Models;
using System.Net;
using System.Text.Json;

namespace DIP.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private LogBase _logBase = new FileLogger();

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                HttpResponse response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case DIPException e:
                        // custom application error
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var err = new { message = "FromMiddleWare:-" + error?.Message };
                string result = JsonSerializer.Serialize(err);
                _logBase.Log($"error --> {err.message}");
                await response.WriteAsync(result);
            }
        }
    }

}
