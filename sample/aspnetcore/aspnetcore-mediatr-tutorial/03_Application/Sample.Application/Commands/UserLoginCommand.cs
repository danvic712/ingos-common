//-----------------------------------------------------------------------
// <copyright file= "UserLoginCommand.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/13 20:28:17
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using System.Runtime.Serialization;

namespace Sample.Application.Commands
{
    public class UserLoginCommand : IRequest<bool>
    {
        /// <summary>
        /// 账户
        /// </summary>
        [DataMember]
        public string Account { get; private set; }

        /// <summary>
        /// 密码
        /// </summary>
        [DataMember]
        public string Password { get; private set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [DataMember]
        public string VerificationCode { get; private set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="account">账户</param>
        /// <param name="password">密码</param>
        /// <param name="verificationCode">验证码</param>
        public UserLoginCommand(string account, string password, string verificationCode)
        {
            Account = account;
            Password = password;
            VerificationCode = verificationCode;
        }
    }
}