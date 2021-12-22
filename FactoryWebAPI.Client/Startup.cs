using FactoryWebAPI.Client.ApiServices.Concrete;
using FactoryWebAPI.Client.ApiServices.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FactoryWebAPI.Client
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSession();


            services.AddControllersWithViews();
            services.AddHttpClient<IAuthService, AuthManager>();
            services.AddHttpClient<IDealerService, DealerManager>();
            services.AddHttpClient<IImageService, ImageManager>();
            services.AddHttpClient<IOrderService, OrderManager>();
            services.AddHttpClient<IProductService, ProductManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePagesWithReExecute("/Auth/StatusCode", "?code={0}");

            app.UseRouting();
            
            app.UseSession();
            app.UseStaticFiles();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(name: default, pattern: "{controller=Auth}/{action=LogIn}");
            });
        }
    }
}
