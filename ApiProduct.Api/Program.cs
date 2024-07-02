using System.Text.Json.Serialization;
using ApiProduct.Api.Configurations;
using ApiProduct.Api.Middlewares;
using ApiProduct.Domain.Infrastructure.CrossCutting;
using ApiProduct.Domain.Infrastructure.Data;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "default", policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();
var configuration = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<JsonOptions>(
    options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddDbContext<SqlContext>(opt =>
     opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
ConfigurationIOC.Register(builder.Services);
var app = builder.Build();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("default");
app.UseMiddleware<MessageNotificatorMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.AddEndpoints();
app.Run();

