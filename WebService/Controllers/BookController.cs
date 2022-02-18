using Application.CreateBook;
using Application.SendMessage;
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

        public BookController(IMediator mediator, IMessageSession messageSession)
        {
            _mediator = mediator;
            _messageSession = messageSession;
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
    }
}
