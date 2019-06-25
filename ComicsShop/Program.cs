using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Sinks;
using System;

namespace ComicsShop
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
           
            var Logger = new LoggerConfiguration()
                .WriteTo.File(@"Logs/log.log", rollingInterval: RollingInterval.Day)
                .MinimumLevel.Debug()
                .CreateLogger();

            var Host = BuildWebHost(args);

            Log.Logger = Logger;

            try
            {
                Startup.WebHostRun(Host, args).Run();
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().UseSerilog().Build();


    }
}
