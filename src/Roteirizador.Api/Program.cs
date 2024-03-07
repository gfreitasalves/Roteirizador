using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Roteirizador.Api;
using Roteirizador.Infrastructure.Database;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = false;
    options.SerializerOptions.IncludeFields = true;
});

builder.Services.AddCors(options =>
{
    //Apenas para dev
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyMethod();
                          policy.AllowAnyOrigin();
                          policy.AllowAnyHeader();                          
                      });
});

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = (int)HttpStatusCode.PermanentRedirect;
    options.HttpsPort = 5143;
});

builder.Services.AddDbContext<RoteirizadorDbContext>(opt => opt.UseInMemoryDatabase("Roteirizador"));

builder.Services.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.RegisterRoutes();

app.Run(app.Configuration["WebApiUrl"]);
