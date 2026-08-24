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

            // Obviously the in memory database is for testing only, and a proper abstracted connection string would be used here.
            services.AddDbContext<NortonDbContext>(options =>
            {
                options.UseInMemoryDatabase("NortonTechTest");
            });

            return services;
        }
    }
}
