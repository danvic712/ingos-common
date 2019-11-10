//-----------------------------------------------------------------------
// <copyright file= "AppUser.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/31 12:25:19
// Modified by:
// Description:
//-----------------------------------------------------------------------
using System;

namespace Sample.Domain.AggregateModels
{
    public class AppUser
    {
        /// <summary>
        /// ctor
        /// </summary>
        private AppUser()
        {
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="name">姓名</param>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <param name="email">电子邮箱</param>
        /// <param name="phone">手机号码</param>
        /// <param name="gender">性别</param>
        /// <param name="address">地址</param>
        public AppUser(Guid id, string name, string account, string password, string email, string phone, bool gender, Address address)
        {
            Id = id;
            Name = name;
            Account = account;
            Password = password;
            Email = email;
            Phone = phone;
            Gender = gender;
            Address = address;
        }

        #region Attributes

        /// <summary>
        /// 主键
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public Address Address { get; set; }

        #endregion Attributes
    }
}