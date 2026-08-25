using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Norton.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Norton.Data.DependencyInjection
{
    public static class DataServiceExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBookRepository>(sp =>
            {
                return new BookRepository(configuration.GetConnectionString("Norton"), sp.GetRequiredService<IMapper>());
            });

            services.AddAutoMapper(typeof(DataServiceExtensions).Assembly);

            return services;
        }
    }
}
