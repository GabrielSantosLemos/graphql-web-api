using HotChocolate.Execution;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.WebAPI.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BuscarAsync([FromServices] IRequestExecutorResolver resolver /* From DI */)
        {
            // See next snippet
            IQueryRequest request = new QueryRequestBuilder().SetQuery(
                @"query {
                  buscarTodosClientes {
                    id,
                    nome
                  }
                }").SetVariableValues(null /* if your query needs varaibles */).Create();

            IRequestExecutor executor = await resolver.GetRequestExecutorAsync();
            IExecutionResult result = await executor.ExecuteAsync(request);

            return Ok();
        }
    }
}
