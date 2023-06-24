using Microsoft.AspNetCore.Mvc;
using SchoolManager.Domain.Shared;
using System.Net;
using System.Text.Json;

namespace SchoolManager.WebAPI.Configs.Middlewares
{
    public sealed class GlobalExceptionHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

        public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                _logger.LogCritical(e, e.Message);

                var httpCode = (int)HttpStatusCode.InternalServerError;

                context.Response.StatusCode = httpCode;

                string json = JsonSerializer.Serialize(new ProblemDetails()
                {
                    Status = httpCode,
                    Type = "Server Error",
                    Title = GlobaErrors.BaseError,
                    Detail = GlobaErrors.BaseError,
                });

                context.Response.ContentType = "application/json";

                await context.Response.WriteAsync(json);
            }
        }
    }
}
