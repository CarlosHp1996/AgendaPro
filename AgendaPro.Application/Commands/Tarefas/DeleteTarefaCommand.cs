using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Tarefas
{
    public class DeleteTarefaCommand : IRequest<Result>
    {
        public Guid Id;

        public DeleteTarefaCommand(Guid id)
        {
            Id = id;
        }
    }
}
