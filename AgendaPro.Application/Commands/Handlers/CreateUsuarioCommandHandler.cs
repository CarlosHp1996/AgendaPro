using AutoMapper;
using AgendaPro.Application.Models.Responses;
using AgendaPro.Domain.Entities.Security;
using AgendaPro.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AgendaPro.Application.Commands.Handlers
{
    public class CreateUsuarioCommandHandler : IRequestHandler<CreateUsuarioCommand, Result<CreateUsuarioResponse>>
    {
        private ApplicationUser _applicationUser;
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public CreateUsuarioCommandHandler(UserManager<ApplicationUser> userManager, IMapper Mapper)
        {
            _userManager = userManager;
        }

        public async Task<Result<CreateUsuarioResponse>> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<CreateUsuarioResponse>();
            var resultado = new IdentityResult();

            _applicationUser = new ApplicationUser();
            _applicationUser.Email = request.Request.Email != null ? request.Request.Email.ToLower()?.Trim() : null;
            _applicationUser.UserName = request.Request.Nome;
            _applicationUser.PhoneNumber = request.Request.Telefone;
            resultado = await _userManager.CreateAsync(_applicationUser, request.Request.Senha);

            if (!resultado.Succeeded)
            {
                result.WithError(resultado.Errors.First().Description);
                return result;
            }

            var response = new CreateUsuarioResponse
            {
                Id = _applicationUser.Id,
                Nome = _applicationUser.UserName,
                Email = _applicationUser.Email,
                Telefone = _applicationUser.PhoneNumber,
                Message = "Usuário criado com sucesso"
            };

            result.Count = 1;
            result.Value = response;
            return result;
        }
    }
}
