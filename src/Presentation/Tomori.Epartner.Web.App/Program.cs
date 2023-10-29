using MudBlazor;
using MudBlazor.Services;
using Tomori.Epartner.Web.App.Helper;
using Tomori.Epartner.Web.Component;
using Tomori.Epartner.Web.Component.Helpers;

namespace Tomori.Epartner.Web.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

            }).AddRazorRuntimeCompilation();

            builder.Services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopRight;
                config.SnackbarConfiguration.ShowCloseIcon = true;
                config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });
            builder.Services.AddAuthentication(HelperClient.AUTHENTICATION_SCHEMA)
                .AddCookie(HelperClient.AUTHENTICATION_SCHEMA, opt =>
                {
                    opt.Cookie.Name = HelperClient.AUTHENTICATION_SCHEMA;
                });

            builder.Services.AddSingleton<ITokenHelper, TokenHelper>();
            builder.Services.RegisterComponent();
            builder.Services.AddSignalR();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
               
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            else
            {
                app.UseWebAssemblyDebugging();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.MapHub<SignalRHub>("/epartner");
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }

    }
}