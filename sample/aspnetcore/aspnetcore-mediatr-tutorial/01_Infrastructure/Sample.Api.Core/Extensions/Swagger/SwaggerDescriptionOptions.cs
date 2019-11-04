//-----------------------------------------------------------------------
// <copyright file= "SwaggerDescriptionOptions.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/3 10:35:02
// Modified by:
// Description:
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Sample.Api.Core.Extensions.Swagger
{
    public class SwaggerDescriptionOptions
    {
        /// <summary>
        /// The author's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The author's email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The author's website address
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// The api's description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The title of swagger doc show
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The collection of api description xml files
        /// </summary>
        public IList<string> Paths { get; set; }
    }
}