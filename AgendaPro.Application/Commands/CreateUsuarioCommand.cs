using AgendaPro.Application.Models.Requests;
using AgendaPro.Application.Models.Responses;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands
{
    public class CreateUsuarioCommand : IRequest<Result<CreateUsuarioResponse>>
    {
        public CreateUsuarioRequest Request;
        public CreateUsuarioCommand(CreateUsuarioRequest request)
        {
            Request = request;
        }
    }
}
