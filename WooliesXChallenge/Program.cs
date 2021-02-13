using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WooliesXChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            CreateHostBuilder(args, config).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, IConfigurationRoot config) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseConfiguration(config)
                        .UseStartup<Startup>();
                });
    }
}
