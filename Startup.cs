using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Add MVC controllers and views support
            services.AddControllersWithViews()
                // Add compability with mvc 3.0 version
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
