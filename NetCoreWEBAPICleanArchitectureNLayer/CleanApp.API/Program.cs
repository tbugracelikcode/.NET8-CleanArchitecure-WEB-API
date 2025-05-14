using CleanApp.API.Extensions;
using CleanApp.Application.Extensions;
using CleanApp.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithFiltersExt();
builder.Services.AddSwaggerGenExt();
builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);
builder.Services.AddExceptionHandlerExt();
builder.Services.AddCachingExt();

var app = builder.Build();

app.UseConfigurePipelineExt();

app.MapControllers();

app.Run();
