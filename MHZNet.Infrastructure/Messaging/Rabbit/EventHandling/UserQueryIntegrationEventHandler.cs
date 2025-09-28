using MHZNet.Common.Helper;
using MHZNet.EventBus.Abstractions;
using MHZNet.IBusiness.Permission;
using MHZNet.Infrastructure.Messaging.Rabbit.Events;
using Microsoft.Extensions.Logging;

namespace MHZNet.Infrastructure.Messaging.Rabbit.EventHandling
{
    /// <summary>
    /// ����rabbitmq�¼�����
    /// </summary>
    public class UserQueryIntegrationEventHandler : IIntegrationEventHandler<UserQueryIntegrationEvent>
    {
        private readonly ILogger<UserQueryIntegrationEventHandler> _logger;
        private readonly IUserService _userService;

        public UserQueryIntegrationEventHandler(IUserService userService,
            ILogger<UserQueryIntegrationEventHandler> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// �����¼�
        /// </summary>
        /// <param name="event"></param>
        public async Task Handle(UserQueryIntegrationEvent @event)
        {
            _logger.LogInformation($"----- Handling integration event: {@event.Id} at {@event}");
            ConsoleHelper.WriteLine($"----- Handling integration event: {@event.Id} at MHZNet - ({@event})");
            await _userService.QueryByIdAsync(@event.UserId);
        }
    }
}
