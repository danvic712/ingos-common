using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetcore_automapper_tutorial.Applications.Post;
using aspnetcore_automapper_tutorial.Applications.Post.Contacts;
using aspnetcore_automapper_tutorial.Core.AutoMapper.Extensions;
using aspnetcore_automapper_tutorial.Core.Routing;
using aspnetcore_automapper_tutorial.Domains.Post;
using aspnetcore_automapper_tutorial.Domains.Post.Contacts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace aspnetcore_automapper_tutorial
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
            // Config automapper mapping rules
            services.AddAutoMapperProfiles();

            services.AddControllersWithViews();

            // Config routing format
            services.AddRouting(options =>
            {
                options.ConstraintMap["slugify"] = typeof(SlugifyParameterTransformer);
                options.LowercaseUrls = true;
            });

            // DI services
            //
            services.AddTransient<IPostAppService, PostAppService>();
            services.AddTransient<IPostDomain, PostDomain>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");
            });
        }
    }
}