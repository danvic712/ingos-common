using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Commands;
using Sample.Application.Dtos;

namespace Sample.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : ControllerBase
    {
        #region Initizalize

        /// <summary>
        ///
        /// </summary>
        private readonly IMediator _mediator;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="mediator"></param>
        public UsersController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        #endregion Initizalize

        #region APIs

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="login">用户登录数据传输对象</param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Post([FromBody] AppUserLoginDto login)
        {
            // 实体映射转换
            var command = new UserLoginCommand(login.Account, login.Password, login.VerificationCode);

            bool flag = await _mediator.Send(command);

            if (flag)
                return Ok(new
                {
                    code = 20001,
                    msg = $"{login.Account} 用户登录成功",
                    data = login
                });
            else
                return Unauthorized(new
                {
                    code = 40101,
                    msg = $"{login.Account} 用户登录失败",
                    data = login
                });
        }

        #endregion APIs
    }
}