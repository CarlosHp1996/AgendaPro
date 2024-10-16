using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Helpers;
using AutoMapper;
using MediatR;

namespace AgendaPro.Application.Queries.Tarefas.Handler
{
    public class GetTarefasQueryHandler : IRequestHandler<GetTarefasQuery, Result<IEnumerable<TarefaResponse>>>
    {
        ITarefaRepository _tarefaRepository;
        IMapper _mapper;

        public GetTarefasQueryHandler(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<TarefaResponse>>> Handle(GetTarefasQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<IEnumerable<TarefaResponse>>();

                var tarefas = await _tarefaRepository.Get(
                    query.Filter.Take,
                    query.Filter.Skip,
                    query.Filter.SortingProp,
                    query.Filter.Ascending,
                    query.Filter.Nome,
                    query.Filter.TarefaCompleta);

                result.Value = tarefas.Result(out var count).Select(p => _mapper.Map<TarefaResponse>(p));
                result.Count = count;

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception("Erro ao listar as tarefas", ex);
            }
        }
    }
}
