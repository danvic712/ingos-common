//-----------------------------------------------------------------------
// <copyright file= "SetCurrentUserEventHandler.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/17 10:43:01
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.DomainEventHandlers.AppUserLogin
{
    public class SetCurrentUserEventHandler : INotificationHandler<AppUserLoginEvent>
    {
        #region Initizalize

        /// <summary>
        ///
        /// </summary>
        private readonly ILogger<SetCurrentUserEventHandler> _logger;

        /// <summary>
        ///
        /// </summary>
        /// <param name="logger"></param>
        public SetCurrentUserEventHandler(ILogger<SetCurrentUserEventHandler> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion Initizalize

        /// <summary>
        /// Notification handler
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task Handle(AppUserLoginEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CurrentUser with Account: {notification.Account} has been successfully setup");

            return Task.FromResult(true);
        }
    }
}