using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SchoolManager.WebAPI.Configs.Middlewares;
using SchoolManager.WebAPI.Configs.Conventions;
using SchoolManager.Application;
using SchoolManager.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<GlobalExceptionHandlingMiddleware>();

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new EndpointConvention());
}).AddNewtonsoftJson(jsonOptions =>
{
    jsonOptions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "School Manager API", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Manager API"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAnyOrigin");

app.Run();
