//-----------------------------------------------------------------------
// <copyright file= "SetLoginRecordEventHandler.cs">
//     Copyright (c) Danvic.Wang All rights reserved.
// </copyright>
// Author: Danvic.Wang
// Created DateTime: 2019/11/17 9:48:53
// Modified by:
// Description:
//-----------------------------------------------------------------------
using MediatR;
using Microsoft.Extensions.Logging;
using Sample.Domain.Events;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sample.Application.DomainEventHandlers.AppUserLogin
{
    public class SetLoginRecordEventHandler : INotificationHandler<AppUserLoginEvent>
    {
        #region Initizalize

        /// <summary>
        ///
        /// </summary>
        private readonly ILogger<SetLoginRecordEventHandler> _logger;

        /// <summary>
        ///
        /// </summary>
        /// <param name="logger"></param>
        public SetLoginRecordEventHandler(ILogger<SetLoginRecordEventHandler> logger)
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
            _logger.LogInformation($"App User with Account: {notification.Account} has been successfully login to site at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")})");

            return Task.FromResult(true);
        }
    }
}