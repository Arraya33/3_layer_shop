using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _3_layer_shop.BLL.Abstract;
using _3_layer_shop.BLL.Interfaces;
using _3_layer_shop.BLL.Services;
using _3_layer_shop.DAL.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _3_layer_shop.WEB
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("ThreeLayerShop");

            services.AddDbContext<SiteDbContext>(options => options.UseSqlServer(connection));

            services.AddTransient<IProductService, DbProductService>();
            services.AddTransient<IInformationService, DbInformationService>();
            services.AddTransient<IBannerService, DbBannerService>();
            services.AddTransient<ICommonService, DbCommonService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(sp => new SessionCartFactory(sp).GetCart());
        
            services.AddMvc();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "discountPage",
                pattern: "Discount",
                defaults: new { controller = "Product", action = "DiscountList" });

                endpoints.MapControllerRoute(
                name: "cartPage",
                pattern: "Cart",
                defaults: new { controller = "Checkout", action = "Cart" });

                endpoints.MapControllerRoute(
                    name: "productPage",
                    pattern: "Product/{productAlias}",
                    defaults: new { controller = "Product", action = "Product" });

                endpoints.MapControllerRoute(
                    name: "articlePage",
                    pattern: "Article/{articleAlias}",
                    defaults: new { controller = "Information", action = "Article" });

                endpoints.MapControllerRoute(
                    name: "productCategoryPage",
                    pattern: "{categoryAlias}",
                    defaults: new { controller = "Product", action = "List" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
