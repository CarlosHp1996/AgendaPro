using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Lembretes.Handler
{
    public class DeleteLembreteCommandHandler : IRequestHandler<DeleteLembreteCommand, Result>
    {
        private readonly ILembreteRepository _lembreteRepository;

        public DeleteLembreteCommandHandler(ILembreteRepository lembreteRepository)
        {
            _lembreteRepository = lembreteRepository;
        }

        public async Task<Result> Handle(DeleteLembreteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result();
                var lembrete = await _lembreteRepository.GetById(request.Id);

                if (lembrete is null)
                {
                    result.WithNotFound("Lembrete não encontrado!");
                    return result;
                }

                await _lembreteRepository.DeleteAsync(lembrete);

                result.Message = "Lembrete excluído com sucesso!";
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
