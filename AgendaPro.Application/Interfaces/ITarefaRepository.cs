using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;

namespace AgendaPro.Application.Interfaces
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        Task<Tarefa> GetTarefaByEventoId(Guid eventoId);
        Task<AsyncOutResult<IEnumerable<Tarefa>, int>> Get(int take, int offset, string sortingProp, bool asc, string? nome, bool? tarefaCompleta);
    }
}
