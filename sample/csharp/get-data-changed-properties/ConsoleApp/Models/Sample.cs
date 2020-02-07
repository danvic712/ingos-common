//-----------------------------------------------------------------------
// <copyright file= "Sample.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2020/2/4 16:08:40
// Modified by:
// Description:
//-----------------------------------------------------------------------
using ConsoleApp.Core;
using System.Collections.Generic;

namespace ConsoleApp.Models
{
    public class Sample
    {
        private string _a;

        public string A
        {
            get => _a;
            set
            {
                if (_a == value)
                    return;

                string old = _a;
                _a = value;
                //propertyChangelogs.Add(new PropertyChangelog<Sample>(nameof(A), old, _a));
            }
        }

        private double _b;

        public double B
        {
            get => _b;
            set
            {
                if (_b == value)
                    return;

                double old = _b;
                _b = value;
                //propertyChangelogs.Add(new PropertyChangelog<Sample>(nameof(B), old.ToString(), _b.ToString()));
            }
        }

        private IList<PropertyChangelog<Sample>> propertyChangelogs = new List<PropertyChangelog<Sample>>();

        public IEnumerable<PropertyChangelog<Sample>> Changelogs() => propertyChangelogs;
    }
}