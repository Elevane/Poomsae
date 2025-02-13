using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Application;
using Poomsae.Server.Application.Services;
using Poomsae.Server.Application.Services.Authentification;
using Poomsae.Server.Application.Services.Authentification.Interfaces;
using Poomsae.Server.Application.Services.External.Mails;
using Poomsae.Server.Application.Services.Helpers;
using Poomsae.Server.Application.Services.Sports.Interfaces;
using Poomsae.Server.Application.Services.UserSports;
using Poomsae.Server.Application.Services.UserSports.Interfaces;
using Poomsae.Server.Application.Utils.Mails;
using Poomsae.Server.Application.Utils.Security;
using Poomsae.Server.Infrastructure;
using Poomsae.Server.Infrastructure.Persistence;
using System.Reflection;
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

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

;

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

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();