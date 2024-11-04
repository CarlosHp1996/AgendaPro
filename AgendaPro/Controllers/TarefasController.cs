using AgendaPro.Application.Commands.Tarefas;
using AgendaPro.Application.Models.Filters;
using AgendaPro.Application.Models.Requests.Tarefas;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Application.Queries.Tarefas;
using AgendaPro.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgendaPro.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TarefasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TarefasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(
             Summary = "Criar tarefas",
             Description = "Todos os campos são obrigatórios.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<TarefaResponse>))]
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateTarefaRequest request)
        {
            var command = new CreateTarefaCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
         Summary = "Alterar tarefas",
         Description = "O 'Id' da tarefa é obrigatório.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<TarefaResponse>))]
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTarefaRequest request)
        {
            var command = new UpdateTarefaCommand(id, request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
             Summary = "Listar todas as tarefas",
             Description = "Lista todas as tarefas de forma paginada.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<TarefaResponse>))]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] GetTarefasRequestFilter filter)
        {
            var command = new GetTarefasQuery(filter);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
            Summary = "Listar todas as tarefas de acordo com o id",
            Description = "O 'Id' da tarefa é obrigatório.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<TarefaResponse>))]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetTarefaByIdQuery(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
            Summary = "Excluir tarefa",
            Description = "O 'Id' da tarefa é obrigatório.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<TarefaResponse>))]
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteTarefaCommand(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
