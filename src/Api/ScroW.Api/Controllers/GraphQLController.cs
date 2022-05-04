using GraphQL.Transport;
using Microsoft.AspNetCore.Mvc;
using ScroW.Api.GraphQL.Net;
using ISchema = GraphQL.Types.ISchema;

namespace GraphQL.GraphiQL.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema schema;
        private readonly IDocumentExecuter executer;

        public GraphQLController(IDocumentExecuter executer, ISchema schema)
        {
            this.executer = executer;
            this.schema = schema;
        }

        [HttpPost("graphqlnet")]
        public async Task<IActionResult> GraphQL([FromBody] GraphQLRequest r)
        {
            var result = await executer.ExecuteAsync(s =>
            {
                s.Schema = schema;
                s.Variables = r?.Variables;
                s.Query = r?.Query;
                s.OperationName = r?.OperationName;
                s.RequestServices = HttpContext.RequestServices;
                s.CancellationToken = HttpContext.RequestAborted;
            });

            return new ExecutionResultActionResult(result);
        }
    }
}