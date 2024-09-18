using AgendaPro.Application.Models.Filters;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Queries.Eventos
{
    public class GetEventosQuery : IRequest<Result<IEnumerable<EventoResponse>>>
    {
        public GetEventosRequestFilter Filter;
        public GetEventosQuery(GetEventosRequestFilter filter)
        {
            Filter = filter;
        }
    }
}
