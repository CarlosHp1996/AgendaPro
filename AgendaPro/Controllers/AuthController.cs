using AgendaPro.Application.Commands.Security;
using AgendaPro.Application.Models.Requests.Security;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioRequest request)
        {
            var command = new CreateUsuarioCommand(request);
            var result = await _mediator.Send(command);

            if (result.HasSuccess)
            {
                return Ok(result);
            }

            return BadRequest(result.Errors);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CreateLoginRequest request)
        {
            var command = new CreateLoginCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

    }
}
