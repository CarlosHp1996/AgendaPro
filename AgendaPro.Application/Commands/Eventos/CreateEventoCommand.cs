using AgendaPro.Application.Models.Requests.Eventos;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos
{
    public class CreateEventoCommand : IRequest<Result<CreateEventoResponse>>
    {
        public CreateEventoRequest Request;
        public CreateEventoCommand(CreateEventoRequest request)
        {
            Request = request;
        }
    }
}
