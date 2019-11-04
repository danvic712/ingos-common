using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        /// 获取全部的用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(IList<AppUserListDto>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public IActionResult Get()
        {
            // 1、Get resource data

            // 2、Determine if the request was successful
            if (true)
                return Ok(new List<AppUserListDto>());
            else
                return BadRequest(new
                {
                    statusCode = StatusCodes.Status400BadRequest,
                    description = "The error description",
                    msg = "The detail error message"
                });
        }

        /// <summary>
        /// 获取用户详细信息
        /// </summary>
        /// <param name="id">用户唯一标识</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AppUserEditDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType(typeof(AppUserEditDto))]
        public IActionResult Get(string id)
        {
            // 1、Get resource data by id
            AppUserEditDto user = null;

            if (user == null)
                return NotFound();
            else
                return Ok(user);
        }

        /// <summary>
        /// 根据条件搜索网站用户信息
        /// </summary>
        /// <param name="search">搜索用户信息数据传输对象</param>
        /// <returns></returns>
        [HttpGet("query")]
        [ProducesResponseType(typeof(IEnumerable<AppUserListDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery]AppUserListSearchDto search)
        {
            return Ok();
        }

        /// <summary>
        /// 新增用户信息
        /// </summary>
        /// <param name="edit">用户编辑信息数据传输对象</param>
        [HttpPost]
        [ProducesResponseType(typeof(AppUserEditDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] AppUserEditDto edit)
        {
            return Created("", new AppUserEditDto());
        }

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="id">用户唯一标识</param>
        /// <param name="edit">用户编辑信息数据传输对象</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AppUserEditDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put(string id, [FromBody] AppUserEditDto edit)
        {
            return Ok();
        }

        /// <summary>
        /// 更新用户状态
        /// </summary>
        /// <param name="id">用户唯一标识</param>
        [HttpPut("{id}/refresh")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AppUserEditDto), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Put(string id)
        {
            return Ok();
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="id">用户唯一标识</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AppUserEditDto), StatusCodes.Status404NotFound)]
        public IActionResult Delete(string id)
        {
            return Delete(id);
        }

        #endregion APIs
    }
}