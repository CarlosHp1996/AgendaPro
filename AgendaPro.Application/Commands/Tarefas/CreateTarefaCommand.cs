using AgendaPro.Application.Models.Requests.Tarefas;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Tarefas
{
    public class CreateTarefaCommand : IRequest<Result<TarefaResponse>>
    {
        public CreateTarefaRequest Request;

        public CreateTarefaCommand(CreateTarefaRequest request)
        {
            Request = request;
        }
    }
}
