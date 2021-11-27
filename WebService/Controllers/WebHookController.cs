using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class WebHookController : ControllerBase
    {
        public WebHookController()
        {

        }
    }
}
