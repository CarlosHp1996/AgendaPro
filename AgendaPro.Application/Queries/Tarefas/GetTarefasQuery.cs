using AgendaPro.Application.Models.Filters;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Queries.Tarefas
{
    public class GetTarefasQuery : IRequest<Result<IEnumerable<TarefaResponse>>>
    {
        public GetTarefasRequestFilter Filter;

        public GetTarefasQuery(GetTarefasRequestFilter filter)
        {
            Filter = filter;
        }
    }
}
