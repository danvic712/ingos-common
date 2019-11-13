//-----------------------------------------------------------------------
// <copyright file= "AppUserConfiguration.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/12 19:15:59
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sample.Domain.AggregateModels;

namespace Sample.Domain.SeedWorks.EntityConfigurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            // 表名称
            builder.ToTable("appuser");

            // 实体属性配置
            builder.OwnsOne(i => i.Address, n =>
            {
                n.Property(p => p.Province).HasMaxLength(50)
                    .HasColumnName("Province")
                    .HasDefaultValue("");

                n.Property(p => p.City).HasMaxLength(50)
                    .HasColumnName("City")
                    .HasDefaultValue("");

                n.Property(p => p.Street).HasMaxLength(50)
                    .HasColumnName("Street")
                    .HasDefaultValue("");

                n.Property(p => p.ZipCode).HasMaxLength(50)
                    .HasColumnName("ZipCode")
                    .HasDefaultValue("");
            });
        }
    }
}