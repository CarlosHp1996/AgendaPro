using AgendaPro.Application.Commands;
using AgendaPro.Application.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPro.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

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

        //    [HttpPost("login")]
        //    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        //    {
        //        var user = await _userManager.FindByEmailAsync(loginDto.Email);

        //        if (user != null && await _userManager.CheckPasswordAsync(user, loginDto.Password))
        //        {
        //            // O método GenerateJwtToken já retorna o AccessToken e o RefreshToken
        //            var token = GenerateJwtToken(user);

        //            return Ok(new
        //            {
        //                token.AccessToken,
        //                token.RefreshToken,
        //                token.Expiration
        //            });
        //        }

        //        return Unauthorized();
        //    }



        //    private Token GenerateJwtToken(IdentityUser user)
        //    {
        //        var claims = new[]
        //        {
        //    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
        //    new Claim("id", user.Id)
        //};

        //        var identity = new ClaimsIdentity(new GenericIdentity(user.UserName, "Login"), claims);

        //        var dataCriacao = DateTime.Now;
        //        var dataExpiracao = dataCriacao.AddMinutes(30);  // Define o tempo de expiração do token

        //        var handler = new JwtSecurityTokenHandler();
        //        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
        //        {
        //            Issuer = "SeuIssuer",
        //            Audience = "SuaAudience",
        //            SigningCredentials = new SigningCredentials(
        //                new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuaChaveSecreta")),
        //                SecurityAlgorithms.HmacSha256
        //            ),
        //            Subject = identity,
        //            NotBefore = dataCriacao,
        //            Expires = dataExpiracao
        //        });

        //        var token = handler.WriteToken(securityToken);

        //        return new Token
        //        {
        //            AccessToken = token,
        //            RefreshToken = GenerateRefreshToken(),
        //            Expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
        //            Authenticated = true,
        //            Message = "Token gerado com sucesso"
        //        };
        //    }

        //    private string GenerateRefreshToken()
        //    {
        //        var randomNumber = new byte[32];
        //        using (var rng = RandomNumberGenerator.Create())
        //        {
        //            rng.GetBytes(randomNumber);
        //            return Convert.ToBase64String(randomNumber);
        //        }
        //    }

    }
}
