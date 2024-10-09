using AgendaPro.Application.Models.Requests.Lembretes;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Lembretes
{
    public class UpdateLembreteCommand : IRequest<Result<LembreteResponse>>
    {
        public Guid Id;
        public UpdateLembreteRequest Request;

        public UpdateLembreteCommand(Guid id, UpdateLembreteRequest request)
        {
            Id = id;
            Request = request;            
        }
    }
}
