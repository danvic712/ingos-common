using aspnetcore_startup.Services.Contact;
using Microsoft.Extensions.Logging;
using System;

namespace aspnetcore_startup.Services
{
    public class StoreService : IStoreService
    {
        /// <summary>
        ///
        /// </summary>
        private readonly ILogger<StoreService> _logger;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        public StoreService(ILogger<StoreService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        ///
        /// </summary>
        public void Store()
        {
            var empty = Guid.Empty;

            if (empty == Guid.Empty)
                empty = Guid.NewGuid();

            _logger.LogInformation($"数据值：{empty}");
        }
    }
}