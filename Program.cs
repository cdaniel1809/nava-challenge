using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using nava_challenge.Tree;
using nava_challenge.Decoder;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           var host = AppStartup();

           ITree tree = ActivatorUtilities.CreateInstance<Tree>(host.Services);

           Console.WriteLine("Introduce the number to decode : ");
           var number_to_decode = Console.ReadLine();

            Console.WriteLine("Decoding ... ");
            tree.LoadTree(number_to_decode);
            Console.WriteLine("the number was decoded ... ");
            Console.WriteLine("Printing combinations decoded ... ");
            tree.PrintLeafs();
        }

        static void ConfigSetup(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddEnvironmentVariables();
        }

        static IHost AppStartup()
        {
            var builder = new ConfigurationBuilder();
            ConfigSetup(builder);

            // defining Serilog configs
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
            
            // Initiated the denpendency injection container 
            var host = Host.CreateDefaultBuilder()
                        .ConfigureServices((context, services) => {
                            services.AddTransient<ITree, Tree>();
                            services.AddTransient<IDecoder, UpperDecoder>();
                          
                        })
                        .UseSerilog()
                        .Build();
            
            return host;
        }
    }
}
