using Back.Api.Domain.Interfaces;
using Back.Api.Infrastructure.Repositories;
using Back.Api.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Registra servicios de infraestructura (email, logging, etc.)
            // services.AddScoped<IEmailService, EmailService>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IJwtService, JwtService>();

            return services;
        }
    }
}
