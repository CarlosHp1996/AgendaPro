using AgendaPro.Application.Interfaces;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Helpers;
using AutoMapper;
using MediatR;

namespace AgendaPro.Application.Queries.Tarefas.Handler
{
    public class GetTarefaByIdQueryHandler : IRequestHandler<GetTarefaByIdQuery, Result<TarefaResponse>>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMapper _mapper;
        public GetTarefaByIdQueryHandler(ITarefaRepository tarefaRepository, IMapper mapper)
        {
            _tarefaRepository = tarefaRepository;
            _mapper = mapper;
        }

        public async Task<Result<TarefaResponse>> Handle(GetTarefaByIdQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var result = new Result<TarefaResponse>();
                var evento = await _tarefaRepository.GetById(query.Id);

                result.Value = _mapper.Map<TarefaResponse>(evento);
                result.Count = 1;
                result.Message = "Tarefa listada com sucesso";
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os eventos", ex);
            }
        }
    }
}
