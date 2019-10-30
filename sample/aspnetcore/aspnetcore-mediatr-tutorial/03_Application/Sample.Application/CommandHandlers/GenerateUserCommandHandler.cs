//-----------------------------------------------------------------------
// <copyright file= "GenerateUserCommandHandler.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/30 11:46:34
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using Sample.Application.Commands;
using Sample.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.CommandHandlers
{
    public class GenerateUserCommandHandler : IRequestHandler<GenerateUserCommand, UserDto>
    {
        public Task<UserDto> Handle(GenerateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}