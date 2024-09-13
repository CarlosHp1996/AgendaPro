using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Application.Models.Responses.Security;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Entities.Security;
using AgendaPro.Domain.Helpers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace AgendaPro.Application.Commands.Eventos.Handler
{
    public class CreateEventoCommandHandler : IRequestHandler<CreateEventoCommand, Result<CreateEventoResponse>>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public CreateEventoCommandHandler(IEventoRepository eventoRepository, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Result<CreateEventoResponse>> Handle(CreateEventoCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<CreateEventoResponse>();

            var user = await _userManager.FindByIdAsync(request.Request.UsuarioId); // O id será pego através do get
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
            //result.Value = _mapper.Map<CreateEventoResponse>(item);
            //result.Count = 1;
            //return result;

            var response = new CreateEventoResponse
            {
                Id = item.Id,
                Titulo = item.Titulo,
                Local = item.Local,
                Descricao = item.Descricao,
                DataInicio = item.DataInicio,
                DataFim = item.DataFim
            };

            result.Count = 1;
            result.Value = response;
            return result;
        }

    }

}
