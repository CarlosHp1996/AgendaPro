using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Queries.Tarefas
{
    public class GetTarefaByIdQuery : IRequest<Result<TarefaResponse>>
    {
        public Guid Id { get; set; }

        public GetTarefaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
