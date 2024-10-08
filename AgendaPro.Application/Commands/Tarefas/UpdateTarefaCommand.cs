using AgendaPro.Application.Models.Requests.Tarefas;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Tarefas
{
    public class UpdateTarefaCommand : IRequest<Result<TarefaResponse>>
    {
        public Guid Id;
        public UpdateTarefaRequest Request;

        public UpdateTarefaCommand(Guid id, UpdateTarefaRequest request)
        {
            Id = id;
            Request = request;
        }
    }
}
