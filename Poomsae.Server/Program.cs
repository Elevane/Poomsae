using Microsoft.AspNetCore.RateLimiting;
using Poomsae.Application;
using Poomsae.Application.Utils.Security;
using Poomsae.Infrastructure.Externals.Mails.Settings;
using Poomsae.Server.Infrastructure;
using Poomsae.Server.Web.Authentification;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
const string appCorsPolicy = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: appCorsPolicy, policy =>
    {
        string? AllowedOrigin = builder.Configuration.GetSection("frontUrl").Value ?? Environment.GetEnvironmentVariable("frontUrl");
        if (AllowedOrigin == null) throw new NullReferenceException($"{nameof(AllowedOrigin)} should not be null in env.");
        string[] AllowedOrigins = new[] { AllowedOrigin };
        policy.WithOrigins(AllowedOrigins).AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithExposedHeaders("x-refresh-token");
    });
});
builder.Services.AddRateLimiter(o =>
{
    o.OnRejected = (context, cancellationToken) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.WriteAsync("Maxi mum request limit reached.");
        return new ValueTask();
    };
    o.AddFixedWindowLimiter(policyName: "poomsae", options =>
    {
        options.PermitLimit = 10;
        options.Window = TimeSpan.FromSeconds(5);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
    });
});
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<MailJetSettings>(builder.Configuration.GetSection("MailJetSettings"));

var app = builder.Build();
app.UseCors(appCorsPolicy);
app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseMiddleware<JwtMiddleware>();
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();