using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Helpers;
using AutoMapper;
using MediatR;

namespace AgendaPro.Application.Queries.Lembretes.Handler
{
    public class GetLembreteByIdQueryHandler : IRequestHandler<GetLembreteByIdQuery, Result<LembreteResponse>>
    {
        private readonly ILembreteRepository _lembreteRepository;
        private readonly IMapper _mapper;
        public GetLembreteByIdQueryHandler(ILembreteRepository lembreteRepository, IMapper mapper)
        {
            _lembreteRepository = lembreteRepository;
            _mapper = mapper;
        }

        public async Task<Result<LembreteResponse>> Handle(GetLembreteByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<LembreteResponse>();
                var evento = await _lembreteRepository.GetById(query.Id);

                result.Value = _mapper.Map<LembreteResponse>(evento);
                result.Count = 1;
                result.Message = "Lembrete listado com sucesso";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os eventos", ex);
            }
        }
    }
}
