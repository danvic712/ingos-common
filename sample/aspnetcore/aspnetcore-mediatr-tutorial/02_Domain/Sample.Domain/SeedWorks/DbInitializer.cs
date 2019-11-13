//-----------------------------------------------------------------------
// <copyright file= "DbInitializer.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/11 21:42:02
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Sample.Domain.AggregateModels;
using System;
using System.Linq;

namespace Sample.Domain.SeedWorks
{
    public class DbInitializer
    {
        public static void Initialize(UserApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.AppUsers.Any())
                return;

            AppUser admin = new AppUser()
            {
                Id = Guid.NewGuid(),
                Name = "墨墨墨墨小宇",
                Account = "danvic.wang",
                Phone = "13912345678",
                Age = 12,
                Password = "123456",
                Gender = true,
                IsEnabled = true,
                Address = new Address("啦啦啦啦街道", "啦啦啦市", "啦啦啦省", "12345"),
                Email = "danvic.wang@yuiter.com",
            };

            context.AppUsers.Add(admin);
            context.SaveChanges();
        }
    }
}