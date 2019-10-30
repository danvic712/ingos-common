//-----------------------------------------------------------------------
// <copyright file= "SwaggerExtension.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/7/27 16:34:40
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sample.Api.Core.Extensions.Swagger
{
    public static class SwaggerExtension
    {
        /// <summary>
        /// Add swagger doc support
        /// </summary>
        /// <param name="services">The instance of <see cref="IServiceCollection"/></param>
        /// <param name="options">The instance of <see cref="SwaggerDescriptionOptions"/></param>
        public static IServiceCollection AddSwagger(this IServiceCollection services, SwaggerDescriptionOptions options)
        {
            // Get the doc config options
            if (options == null)
                throw new ArgumentNullException("The swagger's configuration options is null");

            // Config swagger doc info
            services.AddSwaggerGen(s =>
            {
                // Generate api doc by api version info
                //
                var provider = services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    s.SwaggerDoc(description.GroupName, new OpenApiInfo
                    {
                        Contact = new OpenApiContact
                        {
                            Name = options.Name,
                            Email = options.Email,
                            Url = new Uri(options.Url)
                        },
                        Description = options.Description,
                        Title = options.Title,
                        Version = description.ApiVersion.ToString()
                    });
                }

                // Show api version in the url which swagger doc generated
                s.DocInclusionPredicate((version, apiDescription) =>
                {
                    if (!version.Equals(apiDescription.GroupName))
                        return false;

                    var values = apiDescription.RelativePath
                        .Split('/')
                        .Select(v => v.Replace("v{version}", apiDescription.GroupName)); apiDescription.RelativePath = string.Join("/", values);
                    return true;
                });

                // Let params use the camel naming method
                s.DescribeAllParametersInCamelCase();

                // Remove version param must input in swagger doc
                s.OperationFilter<RemoveVersionFromParameter>();

                // Get project's api description file
                //
                var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
                foreach (var xml in GetApiDocPaths(options, basePath))
                {
                    s.IncludeXmlComments(xml, true);
                }
            });

            return services;
        }

        /// <summary>
        /// Get the api description doc path
        /// </summary>
        /// <param name="options">The instance of <see cref="SwaggerDescriptionOptions"/></param>
        /// <param name="basePath">The site's base running files path</param>
        /// <returns></returns>
        private static IEnumerable<string> GetApiDocPaths(SwaggerDescriptionOptions options, string basePath)
        {
            return from path in options.Paths
                   let xml = Path.Combine(basePath, path)
                   select xml;
        }
    }
}