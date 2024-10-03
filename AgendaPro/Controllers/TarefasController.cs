using AgendaPro.Application.Commands.Tarefas;
using AgendaPro.Application.Models.Requests.Tarefas;
using AgendaPro.Application.Models.Responses.Tarefas;
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
             Summary = "Criar Tarefas",
             Description = "Todos os campos são obrigatórios.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<CreateTarefaResponse>))]
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateTarefaRequest request)
        {
            var command = new CreateTarefaCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
