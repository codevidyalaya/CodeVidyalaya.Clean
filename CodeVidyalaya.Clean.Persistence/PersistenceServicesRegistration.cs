using CodeVidyalaya.Clean.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeVidyalaya.Clean.Persistence
{
    public static class PersistenceServicesRegistration 
    {
        public static IServiceCollection AddPersistenceServices( this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SampleApplicationDatabaseContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("SampleApplicationDatabaseContextConnectionString"));
            });

            return services;
        }
    }
}
