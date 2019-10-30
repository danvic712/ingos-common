//-----------------------------------------------------------------------
// <copyright file= "AppUserLoginEventHandler.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/10/30 11:49:13
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using Sample.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.DomainEventHandlers
{
    public class AppUserLoginEventHandler : INotificationHandler<AppUserLoginEvent>
    {
        public Task Handle(AppUserLoginEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}