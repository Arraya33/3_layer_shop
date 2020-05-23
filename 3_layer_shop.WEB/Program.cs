using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_layer_shop.DAL;
using _3_layer_shop.DAL.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace _3_layer_shop.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();

            using (IServiceScope scope = host.Services.CreateScope())
            {
                IServiceProvider services = scope.ServiceProvider;

                SiteDbContext context = services.GetRequiredService<SiteDbContext>();
                SampleData.InitData(context);

                UserManager<IdentityUser> userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                SampleData.InitIdentityData(userManager);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
