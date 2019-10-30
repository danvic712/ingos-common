//-----------------------------------------------------------------------
// <copyright file= "GenerateUserCommand.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/30 11:45:13
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using Sample.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Application.Commands
{
    public class GenerateUserCommand : IRequest<UserDto>
    {
    }
}