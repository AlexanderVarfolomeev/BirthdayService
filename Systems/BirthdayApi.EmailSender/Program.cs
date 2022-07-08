
// Add services to the container.

using BirthdayApi.EmailSender;
using BirthdayApi.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Settings for the initial configuration
var settings = new WorkerSettings(new SettingsSource());

// Logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog(logger, true);

// Configure services
var services = builder.Services;

services.AddHttpContextAccessor();
services.RegisterServices();


// Start application

var app = builder.Build();


app.StartTaskExecutor();

app.Run();

