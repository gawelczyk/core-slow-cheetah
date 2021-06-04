using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace ConsoleApp_slow {
    class Program {

        public static IConfigurationRoot configuration;

        static int Main(string[] args) {

            try {
                // Start!
                Console.WriteLine("Hello World!");
                ServiceCollection serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

                serviceProvider.GetService<App>().Run();

                return 0;
            } catch {
                return 1;
            }

        }

        private static void ConfigureServices(IServiceCollection serviceCollection) {
            // Add logging
            //serviceCollection.AddSingleton(LoggerFactory.Create(builder => {
            //    builder
            //        .AddSerilog(dispose: true);
            //}));
            //serviceCollection.AddLogging();

            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);

            // Add app
            serviceCollection.AddTransient<App>();
        }
    }

    public class App {
        private readonly IConfigurationRoot config;

        public App(IConfigurationRoot config) {
            this.config = config;
        }
        public void Run() {
            //var val = config.GetSection("EmailAddresses")
            var v1 = config.GetSection("name").Value;
            var v2 = config.GetSection("call").Value;
            var v3 = config.GetSection("email").Value;

            Console.WriteLine("{0} | {1} | {2}", v1, v2, v3);

        }
    }
}
