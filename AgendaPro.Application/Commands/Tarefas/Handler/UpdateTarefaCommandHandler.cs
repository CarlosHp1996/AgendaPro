using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Tarefas.Handler
{
    public class UpdateTarefaCommandHandler : IRequestHandler<UpdateTarefaCommand, Result<TarefaResponse>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public UpdateTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Result<TarefaResponse>> Handle(UpdateTarefaCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<TarefaResponse>();
            var tarefa = await _tarefaRepository.GetTarefaById(request.Id);

            if (tarefa == null)
            {
                result.WithError("Tarefa não encontrada.");
                return result;
            }

            // Atualizando as propriedades da tarefa com os dados enviados na request
            tarefa.Id = request.Id;
            tarefa.Nome = request.Request.Nome;
            tarefa.TarefaCompleta = request.Request.TarefaCompleta;

            var update = await _tarefaRepository.UpdateAsync(tarefa);
            if (!update)
            {
                result.WithError("Erro ao atualizar a tarefa.");
                return result;
            }

            var response = new TarefaResponse()
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                TarefaCompleta = tarefa.TarefaCompleta
            };

            result.Count = 1;
            result.Message = "Tarefa alterada com sucesso!";
            result.HasSuccess = true;
            result.Value = response;
            return result;
        }
    }
}
