//-----------------------------------------------------------------------
// <copyright file= "DateTimeToStringConverter.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/6 19:57:33
// Modified by:
// Description:
//-----------------------------------------------------------------------
using AutoMapper;
using System;

namespace Sample.Infrastructure.AutoMapper.Converters
{
    /// <summary>
    /// Convert datetime to string
    /// </summary>
    public class DateTimeToStringConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime source, ResolutionContext context)
            => source.ToString("yyyy-MM-dd HH:mm:ss");
    }
}