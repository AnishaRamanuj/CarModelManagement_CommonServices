using CarModelManagement_CommonServices.Context.CarModelManagementModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarModelManagement_CommonServices.Repositories;
using CarModelManagement_CommonServices.Services;
using CarModelManagement_CommonServices.Services.Interfaces;
namespace CarModelManagement_CommonServices.API.Extensions
{
    /// App Startup Configuration
    public static class ServiceExtensions
    {
        /// Cross Origin Config
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        /// DB Configuration
        public static void ConfigureDBContext(this IServiceCollection services, IConfiguration config)
        {
            // services.AddDbContext<CarsContext>(opts => opts.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<CarsContext>(opts => opts.UseSqlServer(connectionString));
        }

        /// Dependency Injection(DI)
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Add repositories and services
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarService, CarService>();
          
        }

        /// DI for Configuration Settings
        public static void ConfigureSettings(this IServiceCollection services, IConfiguration config)
        {
        }
    }
}