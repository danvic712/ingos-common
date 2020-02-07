//-----------------------------------------------------------------------
// <copyright file= "Entity.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2020/2/4 15:30:54
// Modified by:
// Description:
//-----------------------------------------------------------------------
using ConsoleApp.Core;
using System;

namespace ConsoleApp
{
    [PropertyChangeTracking]
    public class Entity
    {
        [PropertyChangeTracking(ignore: true)]
        public Guid Id { get; set; }

        [PropertyChangeTracking(displayName: "序号")]
        public string OId { get; set; }

        [PropertyChangeTracking(displayName: "第一个字段")]
        public string A { get; set; }

        public double B { get; set; }

        public bool C { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
    }
}