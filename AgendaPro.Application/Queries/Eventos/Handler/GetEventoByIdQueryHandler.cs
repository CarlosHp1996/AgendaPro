using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Domain.Helpers;
using AutoMapper;
using MediatR;

namespace AgendaPro.Application.Queries.Eventos.Handler
{
    public class GetEventoByIdQueryHandler : IRequestHandler<GetEventoByIdQuery, Result<EventoByIdResponse>>
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;
        public GetEventoByIdQueryHandler(IEventoRepository eventoRepository, IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        public async Task<Result<EventoByIdResponse>> Handle(GetEventoByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<EventoByIdResponse>();
                var evento = await _eventoRepository.GetEventoById(query.Id);

                result.Value = _mapper.Map<EventoByIdResponse>(evento);
                result.Count = 1;
                result.Message = "Evento listado com sucesso";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os eventos", ex);
            }
        }
    }
}
