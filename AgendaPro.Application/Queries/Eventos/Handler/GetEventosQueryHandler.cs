using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Domain.Helpers;
using AutoMapper;
using MediatR;

namespace AgendaPro.Application.Queries.Eventos.Handler
{
    public class GetEventosQueryHandler : IRequestHandler<GetEventosQuery, Result<IEnumerable<EventoResponse>>>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;
        public GetEventosQueryHandler(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<EventoResponse>>> Handle(GetEventosQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<IEnumerable<EventoResponse>>();

                var eventos = await _eventoRepository.Get(
                    query.Filter.Take,
                    query.Filter.Skip,
                    query.Filter.SortingProp,
                    query.Filter.Ascending,
                    query.Filter.Titulo,
                    query.Filter.Descricao,
                    query.Filter.DataInicio,
                    query.Filter.DataFim,
                    query.Filter.Local);

                result.Value = eventos.Result(out var count).Select(p => _mapper.Map<EventoResponse>(p));
                result.Count = count;

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os eventos", ex);
            }
        }


    }
}
