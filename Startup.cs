using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using App.Service;

namespace App
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC controllers and views support
            services.AddControllersWithViews()
                // Add compability with mvc 3.0 version
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Binding appsettings.json config file. Project is a key string from the file
            Configuration.Bind("Project", new Config());

            // The order of enabling services is important!
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage(); // Enable advanced errors logging on errors


            app.UseRouting();
            // Enable static files support like css, js, images and etc 
            app.UseStaticFiles();

            // Register routes (endpoints)
            app.UseEndpoints(endpoints =>
            {
                // Declare the default pattern
                // If there is no controller or action parameters, it will use the default Home and Index.
                // The name of the route is default
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
