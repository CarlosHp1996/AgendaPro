using AgendaPro.Application.Models.Responses.Security;
using AgendaPro.Domain.Entities.Security;
using AgendaPro.Domain.Helpers;
using AgendaPro.Domain.Security;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace AgendaPro.Application.Commands.Security.Handlers
{
    public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, Result<CreateLoginResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AccessManager _accessManager;

        public CreateLoginCommandHandler(UserManager<ApplicationUser> userManager, AccessManager accessManager)
        {
            _userManager = userManager;
            _accessManager = accessManager;
        }

        public async Task<Result<CreateLoginResponse>> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<CreateLoginResponse>();

            // Verifica se o usuário existe pelo email
            var user = await _userManager.FindByEmailAsync(request.Request.Email);
            if (user == null)
            {
                result.WithError("Usuário ou senha inválidos.");
                return result;
            }

            // Verifica se a senha está correta
            if (!await _userManager.CheckPasswordAsync(user, request.Request.Senha))
            {
                result.WithError("Usuário ou senha inválidos.");
                return result;
            }

            // Prepara a resposta
            var response = new CreateLoginResponse
            {
                Id = user.Id,
                Nome = user.UserName,
                Token = _accessManager.GenerateToken(user), //Gera o token
                Mensagem = "Login realizado com sucesso."
            };

            result.Value = response;
            result.Count = 1;
            return result;
        }
    }
}
