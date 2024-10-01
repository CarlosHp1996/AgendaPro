using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos.Handler
{
    public class ActivateEventoCommandHandler : IRequestHandler<ActivateEventoCommand, Result>
    {
        public readonly IEventoRepository _eventoRepository;

        public ActivateEventoCommandHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Result> Handle(ActivateEventoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result();
                var evento = await _eventoRepository.GetById(request.Id);

                if (evento is null) 
                {
                    result.WithNotFound("Evento não encontrado!");
                    return result;
                }

                if (evento!.Ativo)
                {
                    result.WithError("O evento já está ativo.");
                    return result;
                }

                if (evento.DataFim < DateTime.UtcNow)
                {
                    result.WithError("O evento já terminou e não pode ser ativado.");
                    return result;
                }

                evento.Ativo = true;
                var UpdateEvento = await _eventoRepository.UpdateAsync(evento);

                if (!UpdateEvento)
                {
                    result.WithError("Erro ao ativar o evento.");
                    return result;
                }

                result.Message = "Evento ativado com sucesso!";
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
