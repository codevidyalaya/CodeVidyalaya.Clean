using CodeVidyalaya.Clean.Application.Identity;
using CodeVidyalaya.Clean.Application.Models.Identity;
using CodeVidyalaya.Clean.Identity.DbContext;
using CodeVidyalaya.Clean.Identity.Models;
using CodeVidyalaya.Clean.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CodeVidyalaya.Clean.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<SampleApplicationIdentityDatabaseContext>(options =>
            //  options.UseSqlServer(configuration.GetConnectionString("SampleApplicationDatabaseContextConnectionString"),
            
            options.UseMySql(configuration.GetConnectionString("SampleApplicationDatabaseContextConnectionString"),ServerVersion.AutoDetect(configuration.GetConnectionString("SampleApplicationDatabaseContextConnectionString")),
            b => b.MigrationsAssembly(typeof(SampleApplicationIdentityDatabaseContext).Assembly.FullName)));

         
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SampleApplicationIdentityDatabaseContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();


            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(u =>        
            u.TokenValidationParameters = new TokenValidationParameters
            {                
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience= true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = configuration["JwtSettings:Issuer"],
                ValidAudience = configuration["JwtSettings:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtSettings:Key"]))
            });

            return services;
        }
    }
}