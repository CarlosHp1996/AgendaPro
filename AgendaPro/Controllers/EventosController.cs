using AgendaPro.Application.Commands.Eventos;
using AgendaPro.Application.Models.Requests.Eventos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("create")]
        public async Task<IActionResult> CreateEvento(CreateEventoRequest request)
        {
            var command = new CreateEventoCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);          
        }
    }
}
