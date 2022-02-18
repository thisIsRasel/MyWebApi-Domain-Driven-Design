using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SendEvent
{
    public class SendEventConsumer : IConsumer<SendEvent>
    {

        //public Task Consume(ConsumeContext<SendEvent> context)
        //{
        //    _logger.LogInformation("Event received via mass transit!");
        //    return Task.CompletedTask;
        //}

        public Task Consume(ConsumeContext<SendEvent> context)
        {
            Console.WriteLine("Event Received via Mass Transit");
            return Task.CompletedTask;
        }
    }
}
