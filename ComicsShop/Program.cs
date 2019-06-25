using ComicsShop.DAL;
using ComicsShop.Web;
using DAL.DBModels;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace ComicsShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Host = BuildWebHost(args);
            Startup.WebHostRun(Host,args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>().Build();


    }
}
