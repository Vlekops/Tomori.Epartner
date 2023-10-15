using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Helper;
using System.Reflection;
using Tomori.Epartner.API.Helper;

namespace Tomori.Epartner.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.Configure<ApplicationConfig>(options => configuration.Bind(nameof(ApplicationConfig), options));
            
            var type = typeof(DependencyInjection);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IGeneralHelper, GeneralHelper>();
            services.AddTransient<IEmailHelper, EmailHelper>();
            services.AddTransient<ITokenHelper, TokenHelper>();
            services.AddTransient<IRestAPIHelper, RestAPIHelper>();
            return services;
        }
    }
}
