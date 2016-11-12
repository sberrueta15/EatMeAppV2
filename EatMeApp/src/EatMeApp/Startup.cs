using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EatMeApp.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace EatMeApp
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            string mapPath = System.AppContext.BaseDirectory;
            string logPath = Path.Combine((mapPath), "log.log");

            if (!File.Exists(logPath))
            {
                File.Create(logPath).Dispose();
            }

            Log.GetInstance().Init(logPath);

            Log.GetInstance().DoLog("Web Service Iniciado");


            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddCors();

            var connectionString = Configuration["DbContextSettings:ConnectionString"];
            services.AddDbContext<AppDbContext>(
                opts => opts.UseNpgsql(connectionString)
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.UseCors(builder => { builder.WithOrigins("http://54.70.143.222").WithMethods("GET", "PUT", "POST", "DELETE").AllowAnyHeader(); });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}
