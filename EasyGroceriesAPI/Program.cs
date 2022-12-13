using System.Configuration;
using AutoMapper;
using EasyGroceriesAPI.Business;
using EasyGroceriesAPI.Business.Validation;
using EasyGroceriesAPI.DataAccess;
using EasyGroceriesAPI.Domain;
using EasyGroceriesAPI.DTO;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
}); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:EasyGroceriesApiDatabase");

builder.Services.AddDbContext<EasyGroceriesDBContext>(options => {
    
    options.UseSqlite(connectionString, b => b.MigrationsAssembly("EasyGroceriesAPI"));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IOrderProcessor, OrderProcessor>();
builder.Services.AddScoped<IValidatorOrderProcessor, ValidatorOrderProcessor>();
builder.Services.AddScoped<IOrderDiscountProvider, OrderDiscountProvider>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:3000").AllowAnyHeader()
                                                  .AllowAnyMethod().AllowCredentials();
                      });
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

