using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos.Handler
{
    public class DeleteEventoCommandHandler : IRequestHandler<DeleteEventoCommand, Result>
    {
        private readonly IEventoRepository _eventoRepository;

        public DeleteEventoCommandHandler(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        public async Task<Result> Handle(DeleteEventoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result();
                var evento = await _eventoRepository.GetEventoById(request.Id);

                if (evento is null)
                {
                    result.WithNotFound("Evento não encontrado!");
                    return result;
                }

                await _eventoRepository.DeleteAsync(evento);

                result.Message = "Evento excluído com sucesso!";
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
