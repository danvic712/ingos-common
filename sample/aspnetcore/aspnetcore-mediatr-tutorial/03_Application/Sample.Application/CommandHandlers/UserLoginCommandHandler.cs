//-----------------------------------------------------------------------
// <copyright file= "UserLoginCommandHandler.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/13 20:29:37
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using Sample.Application.Commands;
using Sample.Domain.Repositories.Contacts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.CommandHandlers
{
    /// <summary>
    /// 用户登录请求处理
    /// </summary>
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, bool>
    {
        #region Initizalize

        /// <summary>
        /// 仓储实例
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="userRepository"></param>
        public UserLoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        #endregion Initizalize

        /// <summary>
        /// Command Handler
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            // 1、判断验证码是否正确
            if (!request.VerificationCode.Equals("12345"))
                return false;

            // 2、验证登录密码是否正确
            var appUser = await _userRepository.GetAppUserInfo(request.Account.Trim(), request.Password.Trim());
            if (appUser == null)
                return false;

            return true;
        }
    }
}