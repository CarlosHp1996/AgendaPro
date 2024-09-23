using AgendaPro.Application.Commands.Eventos;
using AgendaPro.Application.Models.Filters;
using AgendaPro.Application.Models.Requests.Eventos;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Application.Queries.Eventos;
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
    public class EventosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(
             Summary = "Criar Evento",
             Description = "Todos os campos são obrigatórios.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<EventoResponse>))]
        [HttpPost("create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateEventoRequest request)
        {
            var command = new CreateEventoCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);          
        }

        [SwaggerOperation(
             Summary = "Listar todos os eventos",
             Description = "Listar todos os eventos de forma paginada.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<EventoResponse>))]
        [HttpGet]
        [AllowAnonymous]        
        public async Task<IActionResult> Get([FromQuery]GetEventosRequestFilter filter)
        {
            var command = new GetEventosQuery(filter);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [SwaggerOperation(
             Summary = "Listar todos os eventos de acordo com o id",
             Description = "O 'Id' do evento é obrigatório")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<EventoByIdResponse>))]
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var command = new GetEventoByIdQuery(id);
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
