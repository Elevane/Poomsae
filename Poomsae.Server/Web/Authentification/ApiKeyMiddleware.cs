using Microsoft.Extensions.Options;
using Poomsae.Application.Utils.Security;

namespace Poomsae.Server.Web.Authentification
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public ApiKeyMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            string? headersKey = context.Request.Headers["xapikey"].FirstOrDefault()?.Split(" ").Last();
            if (headersKey == null || headersKey != _appSettings.ApiKey)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key not found.");
                await context.Response.CompleteAsync();
                return;
            }
            else
            {
                await _next(context);
            }
        }
    }
}