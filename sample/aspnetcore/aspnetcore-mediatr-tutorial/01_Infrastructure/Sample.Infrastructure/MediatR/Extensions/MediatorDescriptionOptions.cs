//-----------------------------------------------------------------------
// <copyright file= "MediatorDescriptionOptions.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/16 16:10:43
// Modified by:
// Description:
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Sample.Infrastructure.MediatR.Extensions
{
    public class MediatorDescriptionOptions
    {
        /// <summary>
        /// Startup‘s class type
        /// </summary>
        public Type StartupClassType { get; set; }

        /// <summary>
        /// The assemblies which contains mediator classes
        /// </summary>
        public IEnumerable<string> Assembly { get; set; }
    }
}