//-----------------------------------------------------------------------
// <copyright file= "ApiVersionExtension.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/7/27 16:42:00
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Microsoft.Extensions.DependencyInjection;

namespace Sample.Api.Core.Extensions.ApiVersion
{
    public static class ApiVersionExtension
    {
        /// <summary>
        /// Add api version support
        /// </summary>
        /// <param name="services">The instance of <see cref="IServiceCollection"/></param>
        public static IServiceCollection AddApiVersion(this IServiceCollection services)
        {
            // Add api version support
            services.AddApiVersioning(o =>
            {
                // return api version info in response header
                o.ReportApiVersions = true;

                // default api version
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);

                // when not specifying an api version, select the default version
                o.AssumeDefaultVersionWhenUnspecified = true;
            });

            // Config api version info
            services.AddVersionedApiExplorer(option =>
            {
                // Set api version group name format
                option.GroupNameFormat = "'v'VVVV";

                // when not specifying an api version, select the default version
                option.AssumeDefaultVersionWhenUnspecified = true;
            });

            return services;
        }
    }
}