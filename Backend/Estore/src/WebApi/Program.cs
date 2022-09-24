
using System;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.ApplicationInsights;
using PassMerchantMiddleware.Application;
using PassMerchantMiddleware.Application.Common.Interfaces;
using Persistence;
using Services;
using WebApi.Filters;
using WebApi.Middlewares;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddServices(builder.Configuration);

builder.Services.AddApplication();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddHealthChecks()
    .AddDbContextCheck<ApplicationDbContext>();

builder.Services.AddControllersWithViews(options =>
        options.Filters.Add<ApiExceptionFilterAttribute>())
    .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

builder.Services.AddRazorPages();

// Customise default API behaviour

builder.Services.Configure<ApiBehaviorOptions>(options =>
    options.SuppressModelStateInvalidFilter = true);

builder.Services.AddTransient<ResponseBodyLoggingMiddleware>();
builder.Services.AddTransient<RequestBodyLoggingMiddleware>();

builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddApplicationInsightsTelemetry(a =>
{
    a.ConnectionString = builder.Configuration.GetValue<string>("ApplicationInsights:ConnectionString");
});
builder.Services.AddSingleton<ITelemetryInitializer, ApplicationTelemetryInitializer>();
builder.Services.AddLogging(builder =>
{

    builder.AddFilter<ApplicationInsightsLoggerProvider>("", LogLevel.Trace);
    builder.AddFilter<ApplicationInsightsLoggerProvider>("Microsoft", LogLevel.Debug);
});
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
  
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpLogging();

app.UseCors(a => a.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<RequestBodyLoggingMiddleware>();
app.UseMiddleware<ResponseBodyLoggingMiddleware>();


app.MapControllers();
await Init();
await app.RunAsync();

async Task Init()
{
    try
    {
        using (var scope = app.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
        }
    }
    catch (Exception e)
    {
       

        throw new Exception("An error occurred while migrating or seeding the database.",e);
    }

}