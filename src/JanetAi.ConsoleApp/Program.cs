using System.Text.Json;
using CommonTools;
using FileManagerService;
using JanetAi.Core;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Exceptions;
using UserManagerService;
using UserManagerService.Models;

namespace JanetAi.ConsoleApp
{
    static class Program
    {
        static int Main(string[] p_args)
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.WithExceptionDetails()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(FilePathService.GetLogFile(), rollingInterval: RollingInterval.Day)
                .CreateLogger();
            
            Console.WriteLine(JsonSerializer.Serialize(new UserProfile()));


            try
            {
                Log.Information("Application Starting...");

                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection);
                
                ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
                var janet = serviceProvider.GetRequiredService<JanetAi.Core.JanetAi>();

                // Log your message
                Log.Information("Hello, World!");
                
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application failed to start.");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static void ConfigureServices(IServiceCollection p_services)
        {
            p_services.AddLogging(p_loggingBuilder =>
                p_loggingBuilder.AddSerilog(dispose: true));
            p_services.AddSingleton<JanetAi.Core.JanetAi>();
        }
    }
}