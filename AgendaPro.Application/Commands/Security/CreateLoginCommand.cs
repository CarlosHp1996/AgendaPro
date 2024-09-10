using AgendaPro.Application.Models.Requests.Security;
using AgendaPro.Application.Models.Responses.Security;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Security
{
    public class CreateLoginCommand : IRequest<Result<CreateLoginResponse>>
    {
        public CreateLoginRequest Request;
        public CreateLoginCommand(CreateLoginRequest request)
        {
            Request = request;
        }
    }
}
