using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos.Handler
{
    public class UpdateEventoCommandHandler : IRequestHandler<UpdateEventoCommand, Result<EventoResponse>>
    {
        private readonly IEventoRepository _eventoRepository;

        public UpdateEventoCommandHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Result<EventoResponse>> Handle(UpdateEventoCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<EventoResponse>();
            var evento = await _eventoRepository.GetEventoById(request.Request.EventoId);

            if (evento == null)
            {
                result.WithError("Evento não encontrado.");
                return result;
            }

            // Atualizando as propriedades do evento com os dados enviados na request
            evento.Titulo = request.Request.Titulo;
            evento.Descricao = request.Request.Descricao;
            evento.DataInicio = request.Request.DataInicio;
            evento.DataFim = request.Request.DataFim;
            evento.Local = request.Request.Local;

            // Atualizando Tarefas
            if (request.Request.Tarefas != null && request.Request.Tarefas.Any())
            {
                evento.Tarefas.Clear(); // Limpando as tarefas atuais antes de atualizar a lista
                foreach (var tarefaRequest in request.Request.Tarefas)
                {
                    evento.Tarefas.Add(new Tarefa
                    {
                        Nome = tarefaRequest.Nome,
                        TarefaCompleta = tarefaRequest.TarefaCompleta
                    });
                }
            }

            // Atualizando Lembretes
            if (request.Request.Lembretes != null && request.Request.Lembretes.Any())
            {
                evento.Lembretes.Clear(); // Limpando os lembretes atuais antes de atualizar a lista
                foreach (var lembreteRequest in request.Request.Lembretes)
                {
                    evento.Lembretes.Add(new Lembrete
                    {
                        Descricao = lembreteRequest.Descricao,
                        HoraLembrete = lembreteRequest.HoraLembrete
                    });
                }
            }

            var update = await _eventoRepository.UpdateAsync(evento);
            if (!update)
            {
                result.WithError("Erro ao atualizar o evento.");
                return result;
            }

            var response = new EventoResponse
            {
                Id = evento.Id,
                Titulo = evento.Titulo,
                Local = evento.Local,
                Descricao = evento.Descricao,
                DataInicio = evento.DataInicio,
                DataFim = evento.DataFim,
                Tarefas = evento.Tarefas.Select(t => new TarefaResponse
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    TarefaCompleta = t.TarefaCompleta
                }).ToList(),
                Lembretes = evento.Lembretes.Select(l => new LembreteResponse
                {
                    Id = l.Id,
                    Descricao = l.Descricao,
                    HoraLembrete = l.HoraLembrete
                }).ToList()
            };

            result.Count = 1;
            result.Message = "Evento alterado com sucesso!";
            result.HasSuccess = true;
            result.Value = response;
            return result;
        }
    }
}
