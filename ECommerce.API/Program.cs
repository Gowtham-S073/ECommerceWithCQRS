using Ecommerce.Application.Mapper;
using Ecommerce.Application.RequestModels;
using ECommerce.Domain.Interfaces;
using ECommerce.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ECommerce.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MapperConfig).Assembly);
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddOrderRequestModel).Assembly));

            // Inject IConfiguration
            builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

            builder.Services.AddScoped<IDbConnection>(sp =>
                new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
