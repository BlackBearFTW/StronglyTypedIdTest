using IncrementedIdentifierTest.Infrastructure;
using IncrementedIdentifierTest.Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SchemaFilter<VogenSchemaFilter>();

    c.CustomSchemaIds(t => t.FullName?.Replace("+", ".", StringComparison.Ordinal));
});

builder.Services.AddControllers();

// Exception handling
builder.Services.AddProblemDetails();
builder.Services.AddHttpContextAccessor();

// This will configure the database
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
    .AllowCredentials()); // allow credentials

app.UseExceptionHandler();

app.MapControllers();

app.Run();

public partial class Program;
