using GraphQL;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Infrastructure.Graphql;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class GraphQLController : ControllerBase
    {
        private readonly BookQuery _bookQuery;
        public GraphQLController(BookQuery bookQuery)
        {
            _bookQuery = bookQuery;
        }

        [HttpPost("Query")]
        public async Task<ActionResult> Create([FromBody] GraphQLQuery query)
        {
            var schema = new Schema
            {
                Query = _bookQuery
            };

            var json = await schema.ExecuteAsync(_ =>
            {
                _.Query = query.Query;
            });

            return Ok(json);
        }
    }

    public class GraphQLQuery
    {
        public string Query { get; set; } = default!;
    }
}
