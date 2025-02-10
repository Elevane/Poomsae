using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Poomsae.Server.Application.Interfaces;
using Poomsae.Server.Application.Services;
using Poomsae.Server.Application.Services.External.Mails;
using Poomsae.Server.Application.Services.Helpers;
using Poomsae.Server.Application.Services.Interfaces;
using Poomsae.Server.Application.Utils.Mails;
using Poomsae.Server.Application.Utils.Security;
using Poomsae.Server.Infrastructure.Persistence;
using System.Reflection;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add builder.Services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
builder.Services.AddDbContext<IApplicationContext, ApplicationSqlContext>(options =>
{
    string? conString = builder.Configuration
        .GetSection("ConnectionStrings:DefaultConnection")
        .Value;
    if (conString == null) throw new ArgumentNullException("DefaultConnection secret key could not be found in the environement");
    options.UseMySql(conString, ServerVersion.AutoDetect(conString));
});
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.Configure<MailJetSettings>(builder.Configuration.GetSection("MailJetSettings"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<SecurityHelpers>();
builder.Services.AddScoped<IMailSender, MailJetSender>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISportsService, SportsService>();
builder.Services.AddRateLimiter(o =>
{
    o.OnRejected = (context, cancellationToken) =>
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
        context.HttpContext.Response.WriteAsync("Maxi mum request limit reached.");
        return new ValueTask();
    };
    o.AddFixedWindowLimiter(policyName: "jofa", options =>
    {
        options.PermitLimit = 10;
        options.Window = TimeSpan.FromSeconds(5);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 2;
    });
}
  );

var app = builder.Build();
app.UseCors(appCorsPolicy);
app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
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