//-----------------------------------------------------------------------
// <copyright file= "PropertyChangeTrackingException.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2020/2/5 21:53:16
// Modified by:
// Description:
//-----------------------------------------------------------------------
using System;

namespace ConsoleApp.Core
{
    public class PropertyChangeTrackingException : Exception
    {
        public PropertyChangeTrackingException()
        {
        }

        public PropertyChangeTrackingException(string message) : base(message)
        {
        }

        public PropertyChangeTrackingException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}