using aspnetcore_automapper_tutorial.Core.Configuration;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace aspnetcore_automapper_tutorial.Core.AutoMapper.Extensions
{
    /// <summary>
    /// Automapper configuration extension method
    /// </summary>
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapperProfiles(this IServiceCollection services)
        {
            // Get mapper assemblies info from appsettings.json
            string assemblies = ConfigurationManager.GetConfig("Assembly:Mapper");

            if (!string.IsNullOrEmpty(assemblies))
            {
                var profiles = new List<Type>();

                // The base mapping profile class's type
                var parentType = typeof(Profile);

                foreach (var item in assemblies.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // Get all class which inheritance Profile class
                    //
                    var types = Assembly.Load(item).GetTypes()
                        .Where(i => i.BaseType != null && i.BaseType.Name == parentType.Name);

                    if (types.Count() != 0 || types.Any())
                        profiles.AddRange(types);
                }

                // Add mapping rules
                if (profiles.Count() != 0 || profiles.Any())
                    services.AddAutoMapper(profiles.ToArray());
            }

            return services;
        }
    }
}