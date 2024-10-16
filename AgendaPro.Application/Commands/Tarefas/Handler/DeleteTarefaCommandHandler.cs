using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Tarefas.Handler
{
    public class DeleteTarefaCommandHandler : IRequestHandler<DeleteTarefaCommand, Result>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public DeleteTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Result> Handle(DeleteTarefaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result();
                var tarefa = await _tarefaRepository.GetById(request.Id);

                if (tarefa is null)
                {
                    result.WithNotFound("Tarefa não encontrada!");
                    return result;
                }

                await _tarefaRepository.DeleteAsync(tarefa);

                result.Message = "Tarefa excluída com sucesso!";
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
