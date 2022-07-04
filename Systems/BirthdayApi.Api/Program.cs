using BirthdayApi;
using BirthdayApi.Api.Configuration;
using BirthdayApi.Common;
using BirthdayApi.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var settings = new ApiSettings(new SettingsSource());

// Чтение конфигурации для серилога
builder.Host.UseSerilog((host, cfg) => {
    cfg.ReadFrom.Configuration(host.Configuration);
});

// Add services to the container.
services.AddHttpContextAccessor();

services.AddAppDbContext(settings);

services.AddAppHealthCheck();

services.AddAppSwagger(settings);

services.AddAppCors();

services.AddAppServices();

services.AddAppAuth(settings);

services.AddControllers().AddValidator();

services.AddRazorPages();

services.AddAutoMappers();


var app = builder.Build();

Log.Information("Starting up");

app.UseAppMiddlewares();

app.UseStaticFiles();

app.UseRouting();

app.UseAppCors();

app.UseAppHealthCheck();

app.UseSerilogRequestLogging();

app.UseAppSwagger();

app.UseAppAuth();

app.MapRazorPages();

app.MapControllers();

app.UseAppDbContext();

app.Run();
