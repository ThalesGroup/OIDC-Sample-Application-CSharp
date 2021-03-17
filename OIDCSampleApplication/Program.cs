using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using Microsoft.Extensions.Hosting;

namespace OIDCAppSSO
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
                {
                    Configuration =
                        BuildApplicationConfiguration(hostingContext.HostingEnvironment, configurationBuilder);
                })
                .UseStartup<Startup>()
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 8080, listner =>
                    {
                        listner.UseConnectionLogging();
                    });
                })
                .Build();

        public static IConfiguration BuildApplicationConfiguration(IWebHostEnvironment hostingEnvironment,
            IConfigurationBuilder configurationBuilder)
        {
            if (configurationBuilder == null)
            {
                configurationBuilder = new ConfigurationBuilder();
            }

            if (hostingEnvironment.IsDevelopment())
            {
                configurationBuilder.SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile(@"Config/config.json");
            }
            else
            {
                configurationBuilder.SetBasePath(hostingEnvironment.ContentRootPath).AddJsonFile(
                    Environment.GetEnvironmentVariable("CONFIG_FILE_PATH"), optional: false, reloadOnChange: true);
            }

            IConfiguration configuration = configurationBuilder.Build();
            return configuration;
        }
    }
}
