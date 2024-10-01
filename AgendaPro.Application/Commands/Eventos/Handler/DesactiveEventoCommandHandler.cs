using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos.Handler
{
    public class DesactiveEventoCommandHandler : IRequestHandler<DesactiveEventoCommand, Result>
    {
        public readonly IEventoRepository _eventoRepository;

        public DesactiveEventoCommandHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Result> Handle(DesactiveEventoCommand request, CancellationToken cancellationToken)
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

                if (evento!.Ativo is false)
                {
                    result.WithError("O evento já está desativado.");
                    return result;
                }

                if (evento.DataFim < DateTime.UtcNow)
                {
                    result.WithError("O evento já terminou e não pode ser desativado.");
                    return result;
                }

                evento.Ativo = false;
                var UpdateEvento = await _eventoRepository.UpdateAsync(evento);

                if (!UpdateEvento)
                {
                    result.WithError("Erro ao desativar o evento.");
                    return result;
                }

                result.Message = "Evento desativado com sucesso!";
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
