using AgendaPro.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace AgendaPro.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class ChatGPTController : ControllerBase
    {
        private readonly IOpenAIService _openAIService;

        public ChatGPTController(IOpenAIService openAIService)
        {
            _openAIService = openAIService;
        }

        [SwaggerOperation(
             Summary = "ChatGPT",
             Description = "Todos os campos são obrigatórios.")]
        [HttpPost("ask")]
        [AllowAnonymous]
        public async Task<IActionResult> AskQuestion([FromBody] string pergunta)
        {
            var response = await _openAIService.GetChatGPTResponse(pergunta);
            return Ok(new { Response = response });
        }
    }
}
