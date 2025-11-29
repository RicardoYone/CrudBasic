using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Back.Api.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                 cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //var mapper = new MapperConfiguration(config =>
            //      config.AddProfile(new MapperProfile())
            //    );
            //services.AddSingleton(mapper.CreateMapper());

            // Registra servicios de aplicación, validators, mappers, etc.
            // services.AddScoped<ITuServicio, TuServicio>();
            // services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
