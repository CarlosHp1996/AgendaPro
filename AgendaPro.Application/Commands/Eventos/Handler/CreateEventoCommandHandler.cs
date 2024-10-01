using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Entities.Security;
using AgendaPro.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AgendaPro.Application.Commands.Eventos.Handler
{
    public class CreateEventoCommandHandler : IRequestHandler<CreateEventoCommand, Result<EventoResponse>>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public CreateEventoCommandHandler(IEventoRepository eventoRepository, UserManager<ApplicationUser> userManager)
        {
            _eventoRepository = eventoRepository;
            _userManager = userManager;
        }

        public async Task<Result<EventoResponse>> Handle(CreateEventoCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<EventoResponse>();
            var user = await _userManager.FindByIdAsync(request.Request.UsuarioId);

            if (user == null)
            {
                result.WithError("Usuário não encontrado.");
                return result;
            }

            var evento = new Evento
            {
                UsuarioId = Guid.Parse(request.Request.UsuarioId),
                Titulo = request.Request.Titulo,
                Descricao = request.Request.Descricao,
                DataInicio = request.Request.DataInicio,
                DataFim = request.Request.DataFim,
                Local = request.Request.Local,
                Ativo = true,

                // Mapeando lembretes e tarefas a partir do request
                Lembretes = request.Request.Lembretes.Select(lembrete => new Lembrete
                {
                    Descricao = lembrete.Descricao,
                    HoraLembrete = lembrete.HoraLembrete
                }).ToList(),
                Tarefas = request.Request.Tarefas.Select(tarefa => new Tarefa
                {
                    Nome = tarefa.Nome,
                    TarefaCompleta = tarefa.TarefaCompleta
                }).ToList(),
            };

            var item = await _eventoRepository.AddAsync(evento);
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
                    Nome = t.Nome,
                    TarefaCompleta = t.TarefaCompleta
                }).ToList(),
                Lembretes = evento.Lembretes.Select(l => new LembreteResponse
                {
                    Descricao = l.Descricao,
                    HoraLembrete = l.HoraLembrete
                }).ToList()
            };

            result.Count = 1;
            result.Value = response;
            return result;
        }
    }
}
