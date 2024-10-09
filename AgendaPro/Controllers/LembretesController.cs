using AgendaPro.Application.Commands.Lembretes;
using AgendaPro.Application.Models.Requests.Lembretes;
using AgendaPro.Application.Models.Responses.Lembretes;
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
            Summary = "Criar Lembretes",
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
         Summary = "Alterar Lembretes",
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
    }
}
