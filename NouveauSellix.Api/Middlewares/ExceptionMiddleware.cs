using System.Text.Json;
using NouveauSellix.Domain.Shared;

namespace NouveauSellix.Api.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpException ex)
            {
                context.Response.StatusCode = ex.StatusCode;
                context.Response.ContentType = "application/json";

                var body = new
                {
                    Message = ex.Message,
                    StatusCode = ex.StatusCode
                };

                var jsonBody = JsonSerializer.Serialize(body, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                await context.Response.WriteAsync(jsonBody);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An Unexpected Exception has throw: {ex.Message}");
                _logger.LogError(ex.StackTrace);

                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";

                var body = new
                {
                    Message = "Erro interno.",
                    StatusCode = 500
                };

                var jsonBody = JsonSerializer.Serialize(body, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                await context.Response.WriteAsync(jsonBody);
            }
        }
    }
}
