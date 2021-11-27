using Application.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CreateBook")]
        public async Task<ActionResult> Index()
        {
            var res = await _mediator.Send(new CreateBookCommand());
            return Ok(res);
        }
    }
}
