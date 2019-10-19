using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikeshop.Data.Repositories;
using Bikeshop.Models;
using Bikeshop.Models.Repositories;
using Bikeshop.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Bikeshop
{
    public class Startup
    {        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IProductRepository, ProductRepository>(); //Elke keer we een instantie van de IProductRepository opvragen krijgen we een nieuwe MockProductRepository als return waarde.
            services.AddTransient<IShoppingItemRepository, ShoppingItemRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IShoppingBagRepository, ShoppingBagRepository>(); 
            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            };


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{Controller=Home}/{action=Index}");
            });
        }
    }
}
