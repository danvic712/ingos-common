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
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.CommandHandlers
{
    public class UserLoginCommandHandler : IRequestHandler<UserLoginCommand, bool>
    {
        public Task<bool> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}