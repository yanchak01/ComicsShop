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
            Startup.BuildWebHost(args).Run();
        }

        
                
    }
}
