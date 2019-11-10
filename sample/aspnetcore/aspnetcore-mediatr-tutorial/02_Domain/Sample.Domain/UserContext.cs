//-----------------------------------------------------------------------
// <copyright file= "UserContext.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/10 10:48:05
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Sample.Domain.AggregateModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Domain
{
    public class UserContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}