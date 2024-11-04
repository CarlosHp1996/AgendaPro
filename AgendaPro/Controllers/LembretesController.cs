using AgendaPro.Application.Commands.Lembretes;
using AgendaPro.Application.Models.Filters;
using AgendaPro.Application.Models.Requests.Lembretes;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Application.Queries.Lembretes;
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
    public class LembretesController : ControllerBase
    {
        public readonly IMediator _mediator;

        public LembretesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(
            Summary = "Criar lembretes",
            Description = "Todos os campos são obrigatórios")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<LembreteResponse>))]
        [HttpPost("create")]
        [AllowAnonymous]

        public async Task<IActionResult> Create(CreateLembreteRequest request)
        {
            var command = new CreateLembreteCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
         Summary = "Alterar lembretes",
         Description = "O 'Id' do lembrete é obrigatório.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<LembreteResponse>))]
        [HttpPut("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLembreteRequest request)
        {
            var command = new UpdateLembreteCommand(id, request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
            Summary = "Listar todas os lembretes",
            Description = "Lista todos os lembretes de forma paginada.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<LembreteResponse>))]
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromQuery] GetLembretesRequestFilter filter)
        {
            var command = new GetLembretesQuery(filter);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
            Summary = "Listar todos os lembretes de acordo com o id",
            Description = "O 'Id' do lembrete é obrigatório.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<LembreteResponse>))]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetLembreteByIdQuery(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
            Summary = "Excluir lembrete",
            Description = "O 'Id' do lembrete é obrigatório.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<LembreteResponse>))]
        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteLembreteCommand(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
