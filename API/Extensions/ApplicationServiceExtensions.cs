using System.Text;
using API.Data;
using API.Data.Services;
using API.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services ,IConfiguration config)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddScoped<ITokenService, TokenService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            return services;
        }
        
    }
}