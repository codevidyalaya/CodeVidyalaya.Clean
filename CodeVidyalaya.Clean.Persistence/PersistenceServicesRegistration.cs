using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Persistence.DatabaseContext;
using CodeVidyalaya.Clean.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CodeVidyalaya.Clean.Persistence
{
    public static class PersistenceServicesRegistration 
    {
        public static IServiceCollection AddPersistenceServices( this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<SampleApplicationDatabaseContext>(option =>
            {
                //option.UseSqlServer(configuration.GetConnectionString("SampleApplicationDatabaseContextConnectionString"));
                option.UseMySql(configuration.GetConnectionString("SampleApplicationDatabaseContextConnectionString"),
                    ServerVersion.AutoDetect(configuration.GetConnectionString("SampleApplicationDatabaseContextConnectionString")));
            });
            
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            return services;
        }
    }
}
