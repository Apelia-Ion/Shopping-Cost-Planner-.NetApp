using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCostPlanner.Application.Interfaces.Repository;
using ShoppingCostPlanner.Application.Options;
using ShoppingCostPlanner.Application.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCostPlanner.Application.Interfaces.Service
{
    public static class ConfigureServices
    {
        public static void AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SendGridOptions>(options => configuration.GetSection("SendGrid").Bind(options));
        }
        public static void AddServices(this IServiceCollection services)
        {

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IUserService, UserService>();
            //can't add refference to using ShoppingCostPlanner.Infrastructure.Repositories; -> circular refference 
            //So i will let the next line in program.cs
            //services.AddTransient<IUserRepository, UserRepository>();
        }

    }
}
