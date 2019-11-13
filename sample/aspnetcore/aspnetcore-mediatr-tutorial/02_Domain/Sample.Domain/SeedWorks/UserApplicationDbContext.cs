//-----------------------------------------------------------------------
// <copyright file= "UserApplicationDbContext.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/11 21:40:18
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Sample.Domain.AggregateModels;
using Sample.Domain.SeedWorks.EntityConfigurations;

namespace Sample.Domain.SeedWorks
{
    public class UserApplicationDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public UserApplicationDbContext(DbContextOptions<UserApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 自定义 AppUser 表创建规则
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}