using AgendaPro.Application.Commands.Security;
using AgendaPro.Application.Models.Requests.Security;
using AgendaPro.Application.Models.Responses.Security;
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
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [SwaggerOperation(
              Summary = "Criar usuário",
              Description = "Criação de um novo usuário.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<CreateUsuarioResponse>))]
        [HttpPost("create")]
        [AllowAnonymous]        
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

        [SwaggerOperation(
            Summary = "Login do usuário",
            Description = "Login do usuário e geração do token de autenticação.")]
        [SwaggerResponse(200, "Sucesso", typeof(Result<CreateUsuarioResponse>))]
        [HttpPost("login")]
        [AllowAnonymous]        
        public async Task<IActionResult> Login([FromBody] CreateLoginRequest request)
        {
            var command = new CreateLoginCommand(request);
            var response = await _mediator.Send(command);

            return Ok(response);
        }

    }
}
