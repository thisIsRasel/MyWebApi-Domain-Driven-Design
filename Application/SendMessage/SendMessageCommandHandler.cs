using Microsoft.Extensions.Logging;
using NServiceBus;

namespace Application.SendMessage
{
    public class SendMessageCommandHandler
        : IHandleMessages<SendMessageCommand>
    {
        private readonly ILogger<SendMessageCommandHandler> _logger;

        public SendMessageCommandHandler(ILogger<SendMessageCommandHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SendMessageCommand message, IMessageHandlerContext context)
        {
            _logger.LogInformation("Message received!");
            return Task.CompletedTask;
        }
    }
}
