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
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Application.Commands
{
    public class UserLoginCommand : IRequest<bool>
    {
    }
}