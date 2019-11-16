//-----------------------------------------------------------------------
// <copyright file= "UserRepository.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/30 11:51:46
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Microsoft.EntityFrameworkCore;
using Sample.Domain.AggregateModels;
using Sample.Domain.Repositories.Contacts;
using Sample.Domain.SeedWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Initialize

        /// <summary>
        /// 数据库上下文对象
        /// </summary>
        private readonly UserApplicationDbContext _context;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(UserApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        #endregion Initialize

        #region Services

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="account">账户名</param>
        /// <param name="password">密码</param>
        /// <returns></returns>
        public async Task<AppUser> GetAppUserInfo(string account, string password)
        {
            using (_context)
            {
                var appUser = await _context.AppUsers
                    .FirstOrDefaultAsync(i => i.Account.Equals(account) && i.Password.Equals(password));

                return appUser;
            }
        }

        #endregion Services
    }
}