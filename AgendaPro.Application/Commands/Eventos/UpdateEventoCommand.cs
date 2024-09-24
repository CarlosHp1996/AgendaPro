using AgendaPro.Application.Models.Requests.Eventos;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos
{
    public class UpdateEventoCommand : IRequest<Result<EventoResponse>>
    {
        public Guid Id;
        public UpdateEventoRequest Request;

        public UpdateEventoCommand(Guid id, UpdateEventoRequest request)
        {
            Id = id;
            Request = request;            
        }
    }
}
