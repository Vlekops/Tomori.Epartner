using Blazored.LocalStorage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tomori.Epartner.Web.Component.Helpers;
using Tomori.Epartner.Web.Component.Services;
using System.Reflection;

namespace Tomori.Epartner.Web.Component
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterComponent(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IRequestHelper, RequestHelper>();
            services.AddBlazoredLocalStorage();

            var appServices = Assembly.Load("Tomori.Epartner.Web.Component").GetTypes().Where(s => s.Name.EndsWith("Service") && s.IsInterface == false).ToList();
            foreach (var appService in appServices)
            {
                services.AddTransient(appService.GetInterface($"I{appService.Name}"), appService);
            }
            return services;
        }
    }
}
