using CodeVidyalaya.Clean.Api.Middleware;
using CodeVidyalaya.Clean.Application;
using CodeVidyalaya.Clean.Identity;
using CodeVidyalaya.Clean.Infrastructure;
using CodeVidyalaya.Clean.Persistence;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddControllers().AddJsonOptions(x=>x.JsonSerializerOptions.ReferenceHandler= ReferenceHandler.IgnoreCycles);

builder.Services.AddCors(options =>
{
    options.AddPolicy("all", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
