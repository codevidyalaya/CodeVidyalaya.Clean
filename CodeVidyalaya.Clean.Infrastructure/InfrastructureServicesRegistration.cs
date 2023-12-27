using CodeVidyalaya.Clean.Application.Contracts.Logging;
using CodeVidyalaya.Clean.Application.Models.Email;
using CodeVidyalaya.Clean.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CodeVidyalaya.Clean.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("EmailSetting"));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}