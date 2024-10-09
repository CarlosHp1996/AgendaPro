using AgendaPro.Application.Models.Requests.Lembretes;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Lembretes
{
    public class CreateLembreteCommand : IRequest<Result<LembreteResponse>>
    {
        public CreateLembreteRequest Request;

        public CreateLembreteCommand(CreateLembreteRequest request)
        {
            Request = request;
        }
    }
}
