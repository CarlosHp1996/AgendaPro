using AgendaPro.Application.Models.Filters;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Queries.Lembretes
{
    public class GetLembretesQuery : IRequest<Result<IEnumerable<LembreteResponse>>>
    {
        public GetLembretesRequestFilter Filter;

        public GetLembretesQuery(GetLembretesRequestFilter filter)
        {
            Filter = filter;
        }
    }
}
