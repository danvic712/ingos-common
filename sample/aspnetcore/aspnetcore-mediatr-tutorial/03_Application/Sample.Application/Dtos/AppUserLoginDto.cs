//-----------------------------------------------------------------------
// <copyright file= "AppUserLoginDto.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/13 20:22:56
// Modified by:
// Description:
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Sample.Application.Dtos
{
    /// <summary>
    /// 用户登录数据传输对象
    /// </summary>
    public class AppUserLoginDto
    {
        #region Attributes

        /// <summary>
        /// 账户
        /// </summary>
        [Required]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        public string VerificationCode { get; set; }

        #endregion Attributes
    }
}