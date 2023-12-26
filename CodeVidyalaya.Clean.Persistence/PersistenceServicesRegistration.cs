using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeVidyalaya.Clean.Persistence
{
    public static class PersistenceServicesRegistration 
    {
        public static IServiceCollection AddPersistenceServices( this IServiceCollection services,IConfiguration configuration)
        {
            return services;
        }
    }
}
