//-----------------------------------------------------------------------
// <copyright file= "MediatRExtension.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/16 15:42:37
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sample.Infrastructure.MediatR.Extensions
{
    public static class MediatRExtension
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="services">The instance of <see cref="IServiceCollection"/></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomMediatR(this IServiceCollection services, MediatorDescriptionOptions options)
        {
            // Get Startup's type
            var mediators = new List<Type> { options.StartupClassType };

            // The base request interface's type
            var parentRequestType = typeof(IRequest<>);

            // The base notification interface's type
            var parentNotificationType = typeof(INotification);

            foreach (var item in options.Assembly)
            {
                var instances = Assembly.Load(item).GetTypes();

                foreach (var instance in instances)
                {
                    // Get the interfaces info
                    //
                    var baseInterfaces = instance.GetInterfaces();
                    if (baseInterfaces.Count() == 0 || !baseInterfaces.Any())
                        continue;

                    // Get all class which inheritance the IRequest<T> interface
                    //
                    var requestTypes = baseInterfaces.Where(i => i.IsGenericType
                        && i.GetGenericTypeDefinition() == parentRequestType);

                    if (requestTypes.Count() != 0 || requestTypes.Any())
                        mediators.Add(instance);

                    // Get all class which inheritance the INotification interface
                    //
                    var notificationTypes = baseInterfaces.Where(i => i.FullName == parentNotificationType.FullName);

                    if (notificationTypes.Count() != 0 || notificationTypes.Any())
                        mediators.Add(instance);
                }
            }

            // Add mediators
            services.AddMediatR(mediators.ToArray());

            return services;
        }
    }
}