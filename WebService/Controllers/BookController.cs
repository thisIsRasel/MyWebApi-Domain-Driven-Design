using Application.CreateBook;
using Application.SendEvent;
using Application.SendMessage;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using System.Net.Mime;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMessageSession _messageSession;
        private readonly IPublishEndpoint _publishEndpoint;

        public BookController(
            IMediator mediator,
            IMessageSession messageSession,
            IPublishEndpoint publishEndpoint)
        {
            _mediator = mediator;
            _messageSession = messageSession;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("CreateBook")]
        public async Task<ActionResult> Create([FromBody] CreateBookCommand command)
        {
            var res = await _mediator.Send(command);

            await _messageSession.Send(command)
                .ConfigureAwait(false);

            return Ok(res);
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult> SendMessage([FromBody] SendMessageCommand command)
        {
            await _messageSession.Send(command)
                .ConfigureAwait(false);

            return Ok();
        }

        [HttpPost("SendEvent")]
        public async Task<ActionResult> SendEvent([FromBody] SendEvent command)
        {
            await _publishEndpoint.Publish(command);

            return Ok();
        }
    }
}
