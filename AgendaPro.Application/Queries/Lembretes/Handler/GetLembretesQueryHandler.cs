using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Helpers;
using AutoMapper;
using MediatR;

namespace AgendaPro.Application.Queries.Lembretes.Handler
{
    public class GetLembretesQueryHandler : IRequestHandler<GetLembretesQuery, Result<IEnumerable<LembreteResponse>>>
    {
        ILembreteRepository _lembreteRepository;
        IMapper _mapper;

        public GetLembretesQueryHandler(ILembreteRepository lembreteRepository, IMapper mapper)
        {
            _lembreteRepository = lembreteRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<LembreteResponse>>> Handle(GetLembretesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<IEnumerable<LembreteResponse>>();

                var lembretes = await _lembreteRepository.Get(
                    query.Filter.Take,
                    query.Filter.Skip,
                    query.Filter.SortingProp,
                    query.Filter.Ascending,
                    query.Filter.Descricao,
                    query.Filter.HoraLembrete);

                result.Value = lembretes.Result(out var count).Select(p => _mapper.Map<LembreteResponse>(p));
                result.Count = count;

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar os lembretes", ex);
            }
        }
    }
}
