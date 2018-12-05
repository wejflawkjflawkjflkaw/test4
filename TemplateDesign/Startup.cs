using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//..
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Project.Services;

namespace Project
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
            services.AddMvc();
            services.AddIdentity<IdentityUser, IdentityRole>
            (
              config =>
              {
                  config.Password.RequiredLength = 3;
                  config.Password.RequireUppercase = false;
                  config.Password.RequireDigit = false;
                  config.Password.RequireNonAlphanumeric = false;
              }
            ).AddEntityFrameworkStores<MyDbContext>();
            services.AddDbContext<MyDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvcWithDefaultRoute();


            //    app.UseMvc(routes =>
            //    {
            //        routes.MapRoute(
            //            name: "default",
            //            template: "{controller=Home}/{action=Index}/{id?}");
            //    });

            }
        }
    }
