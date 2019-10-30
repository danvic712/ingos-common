//-----------------------------------------------------------------------
// <copyright file= "UserRepository.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/30 11:51:46
// Modified by:
// Description:
//-----------------------------------------------------------------------
using Sample.Domain.AggregateModels;
using Sample.Domain.Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        #region Services

        /// <summary>
        /// Get user info by email address
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns></returns>
        public Task<AppUser> GetAppUserInfoByEmail(string email)
        {
            throw new NotImplementedException();
        }

        #endregion Services
    }
}