using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sample.Api.Core.Extensions.ApiVersion;
using Sample.Api.Core.Extensions.Swagger;
using Sample.Domain;
using Sample.Domain.SeedWorks;
using Sample.Infrastructure.AutoMapper.Extensions;

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
            services.AddMvc(// Add cors authorization filter
                options => options.Filters.Add(new CorsAuthorizationFilterFactory(_defaultCorsPolicyName))
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Config automapper mapping rules
            services.AddAutoMapperProfiles();

            // Config mysql server database connection
            services.AddDbContext<UserApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("SampleConnection")));

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
                    )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()));

            // Add swagger api doc support
            services.AddSwagger(new SwaggerDescriptionOptions
            {
                Name = "Danvic Wang",
                Email = "danvic96@hotmail.com",
                Url = "https://yuiter.com",
                Description = "Sample.API 接口文档",
                Title = "Sample.API",
                Paths = new List<string> { "Sample.Api.xml", "Sample.Application.xml" }
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Allow cross domain request
            app.UseCors(_defaultCorsPolicyName);

            app.UseHttpsRedirection();
            app.UseMvc();

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