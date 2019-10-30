using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Api.Core.Extensions.ApiVersion;
using Sample.Api.Core.Extensions.Swagger;

namespace Sample.Api
{
    public class Startup
    {
        // Default Cors policy name
        private const string _defaultCorsPolicyName = "Sample.Api.Cors";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Use lowercase urls router mode
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
            });

            // Config api version
            services.AddApiVersion();

            // Config cors policy
            services.AddCors(options => options.AddPolicy(_defaultCorsPolicyName,
                builder => builder.WithOrigins(
                        Configuration["Application:CorsOrigins"]
                        .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray()
                    )));

            // Add swagger api doc support
            services.AddSwagger(new SwaggerDescriptionOptions
            {
                Name = "Danvic Wang",
                Email = "danvic96@hotmail.com",
                Url = "https://yuiter.com",
                Description = "Sample.API ½Ó¿ÚÎÄµµ",
                Title = "Sample.API",
                Paths = new List<string> { "Sample.Api.xml", "Sample.Application.xml" }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Allow cross domain request
            app.UseCors(_defaultCorsPolicyName);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable swagger doc
            app.UseSwagger();

            app.UseSwaggerUI(s =>
            {
                // Default load the latest version
                foreach (var description in provider.ApiVersionDescriptions.Reverse())
                {
                    s.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        $"Sample API {description.GroupName.ToUpperInvariant()}");
                }
            });
        }
    }
}