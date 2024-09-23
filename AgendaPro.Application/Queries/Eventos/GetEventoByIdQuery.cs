using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Queries.Eventos
{
    public class GetEventoByIdQuery : IRequest<Result<EventoByIdResponse>>
    {
        public Guid Id { get; set; }

        public GetEventoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
