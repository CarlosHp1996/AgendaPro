using AgendaPro.Application.Models.Requests.Security;
using AgendaPro.Application.Models.Responses.Security;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Security
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
