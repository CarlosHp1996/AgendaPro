using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Lembretes.Handler
{
    public class UpdateLembreteCommandHandler : IRequestHandler<UpdateLembreteCommand, Result<LembreteResponse>>
    {
        private readonly ILembreteRepository _lembreteRepository;

        public UpdateLembreteCommandHandler(ILembreteRepository lembreteRepository)
        {
            _lembreteRepository = lembreteRepository;
        }

        public async Task<Result<LembreteResponse>> Handle(UpdateLembreteCommand request, CancellationToken cancellationToken)
        {
            var result = new Result<LembreteResponse>();

            try
            {                
                var lembrete = await _lembreteRepository.GetById(request.Id);

                if (lembrete is null)
                {
                    result.WithError("Lembrete não encontrado.");
                    return result;
                }

                // Atualizando as propriedades do lembrete com os dados enviados na request
                lembrete.Id = request.Id;
                lembrete.Descricao = request.Request.Descricao;
                lembrete.HoraLembrete = request.Request.HoraLembrete;

                var update = await _lembreteRepository.UpdateAsync(lembrete);
                if (!update)
                {
                    result.WithError("Erro ao atualizar o lembrete.");
                    return result;
                }

                var response = new LembreteResponse()
                {
                    Id = lembrete.Id,
                    Descricao = lembrete.Descricao,
                    HoraLembrete = lembrete.HoraLembrete
                };

                result.Count = 1;
                result.Message = "Lembrete alterado com sucesso!";
                result.HasSuccess = true;
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
