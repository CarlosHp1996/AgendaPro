using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Tarefas.Handler
{
    public class CreateTarefaCommandHandler : IRequestHandler<CreateTarefaCommand, Result<CreateTarefaResponse>>
    {
        private readonly ITarefaRepository _tarefaRepository;

        public CreateTarefaCommandHandler(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Result<CreateTarefaResponse>> Handle(CreateTarefaCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<CreateTarefaResponse>();
            var evento = await _tarefaRepository.GetTarefaByEventoId(request.Request.EventoId);

            if (evento == null)
            {
                result.WithError("Evento não encontrado.");
                return result;
            }

            var tarefa = new Tarefa()
            {
                Nome = request.Request.Nome,
                EventoId = request.Request.EventoId,
                TarefaCompleta = request.Request.TarefaCompleta
            };

            var item = await _tarefaRepository.AddAsync(tarefa);
            var response = new CreateTarefaResponse
            {
                Id = tarefa.Id,
                Nome = tarefa.Nome,
                TarefaCompleta = tarefa.TarefaCompleta
            };

            result.Value = response;
            return result;
        }
    }
}
