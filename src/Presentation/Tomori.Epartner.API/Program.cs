using Tomori.Epartner.Core;
using Tomori.Epartner.Data;
using Serilog.Formatting.Compact;
using Serilog;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using System.Text;
using Hangfire;
using Hangfire.SqlServer;
using HangfireBasicAuthenticationFilter;
using Tomori.Epartner.API.Handler;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace Tomori.Epartner.API
{
    public class Program
    {
        private const string _defaultCorsPolicyName = "localhost";
        private IConfiguration _configuration { get; }
        private IWebHostEnvironment _environment { get; set; }

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IWebHostEnvironment _environment = builder.Environment;
            string _environtmentName = "Development";
            if (builder.Environment.IsDevelopment())
                _environtmentName = "Development";
            else if (builder.Environment.IsStaging())
                _environtmentName = "Staging";
            else if (builder.Environment.IsProduction())
                _environtmentName = "Production";

            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                      .AddJsonFile("appsettings.json")
                                                      .AddJsonFile($"appsettings.{_environtmentName}.json", optional: true)
                                                      .AddEnvironmentVariables()
                                                      .Build();


            IConfiguration _configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .ReadFrom.Configuration(configuration)
                //.Filter.ByExcluding((le) => le.Level == Serilog.Events.LogEventLevel.Information)
                .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .WriteTo.File(
                    new CompactJsonFormatter(),
                    path: Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log", "Application_.json"),
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning,
                    fileSizeLimitBytes: 524288000,
                    rollingInterval: RollingInterval.Day
            )
                .CreateLogger();


            builder.Services.AddControllers();

            builder.Services.RegisterData(_configuration);
            builder.Services.RegisterCore(_configuration);

            builder.Services.AddHsts(options =>
            {
                options.IncludeSubDomains = true;
            });
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("ApplicationConfig")["SecretKey"]);
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidIssuer = _configuration.GetSection("ApplicationConfig")["Issuer"],
                   ValidAudience = _configuration.GetSection("ApplicationConfig")["Audience"],
                   ValidateLifetime = true,
                   ClockSkew = TimeSpan.Zero
               };
               x.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = context =>
                   {
                       if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                       {
                           context.Response.Headers.Add("Token-Expired", "true");
                       }
                       return Task.CompletedTask;
                   }
               };
           });
            builder.Services.AddAuthorization(options =>
            {

            });

            builder.Services.AddAntiforgery(options =>
            {
                options.SuppressXFrameOptionsHeader = true;
            });

            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(typeof(Handler.AuthorizeFilter));
            });
            builder.Services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });

            builder.Services.AddRazorPages().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;

            });
            builder.Services.AddHealthChecks();

            builder.Services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(_configuration.GetSection("HangFire")["Connection"], new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    DisableGlobalLocks = true
                }));

            // Add the processing server as IHostedService
            builder.Services.AddHangfireServer();

            if (_environment.IsDevelopment())
            {
                builder.Services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tomori.Epartner.API", Version = "v1" });
                    c.AddSecurityDefinition("Bearer",
                        new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.Http,
                            BearerFormat = "JWT",
                            Scheme = "Bearer",
                            In = ParameterLocation.Header,
                            Name = Microsoft.Net.Http.Headers.HeaderNames.Authorization,
                            Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')"
                        }
                    );
                    c.AddSecurityRequirement(
                        new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer"
                                    },
                                },
                                Array.Empty<string>()
                            }
                        });
                    c.EnableAnnotations();
                    c.MapType<TimeSpan>(() => new OpenApiSchema
                    {
                        Type = "string",
                        Example = new OpenApiString("00:00:00")
                    });
                });
                builder.Services.AddSwaggerGen();
            }

            builder.Services.AddCors(
                options => options.AddPolicy(
                    _defaultCorsPolicyName,
                    builder => builder
                        .WithOrigins(
                            _configuration.GetValue<string>("AllowedHosts").Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray()
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                )
            );

            var app = builder.Build();


            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.DocumentTitle = "Tomori.Epartner.API";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
                });
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHangfireDashboard("/" + _configuration.GetSection("HangFire")["URL"], new DashboardOptions
            {
                DashboardTitle = "JOB",
                Authorization = new[] {
                    new HangfireCustomBasicAuthenticationFilter{
                    User = _configuration.GetSection("HangFire")["UserName"],
                    Pass = _configuration.GetSection("HangFire")["Password"]
                }
                },
                IgnoreAntiforgeryToken = true,
                DisplayStorageConnectionString = false
            });
            app.UseCookiePolicy();
            app.UseHealthChecks("/health");
            app.MapHealthChecks("/database_health");
            app.UseCors(_defaultCorsPolicyName);
            app.MapControllers();

            app.Run();
        }
    }
}