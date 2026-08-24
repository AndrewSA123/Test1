using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Norton.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Norton.Data.DependencyInjection
{
    public static class DataServiceExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();

            return services;
        }
    }
}
