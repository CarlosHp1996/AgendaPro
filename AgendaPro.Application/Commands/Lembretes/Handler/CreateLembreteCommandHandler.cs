using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Lembretes.Handler
{
    public class CreateLembreteCommandHandler : IRequestHandler<CreateLembreteCommand, Result<LembreteResponse>>
    {
        public readonly ILembreteRepository _lembreteRepository;

        public CreateLembreteCommandHandler(ILembreteRepository lembreteRepository)
        {
            _lembreteRepository = lembreteRepository;
        }

        public async Task<Result<LembreteResponse>> Handle(CreateLembreteCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<LembreteResponse>();

            try
            {
                var lembreteId = await _lembreteRepository.GetLembreteByEventoId(request.Request.EventoId);

                if (lembreteId is null)
                {
                    result.WithError("Evento não encontrado.");
                    return result;
                }

                var lembrete = new Lembrete()
                {
                    Descricao = request.Request.Descricao,
                    EventoId = request.Request.EventoId,
                    HoraLembrete = request.Request.HoraLembrete
                };

                _ = await _lembreteRepository.AddAsync(lembrete);

                var response = new LembreteResponse
                {
                    Id = lembrete.Id,
                    Descricao = lembrete.Descricao,
                    HoraLembrete = lembrete.HoraLembrete
                };

                result.Count = 1;
                result.Value = response;
            }
            catch (Exception)
            {

                throw;
            }

            return result;         
        }
    }
}
