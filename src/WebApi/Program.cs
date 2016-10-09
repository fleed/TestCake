using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    using System.IO;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var configBuilder = new ConfigurationBuilder().SetBasePath(currentDirectory);
            configBuilder = configBuilder.AddJsonFile("hosting.json");

            var config = configBuilder.Build();

            var host =
                new WebHostBuilder()
                .UseKestrel()
                    .UseConfiguration(config)
                    .UseIISIntegration()
                    .UseContentRoot(currentDirectory)
                    .UseStartup<Startup>()
                    .Build();
            host.Run();
        }
    }
}
