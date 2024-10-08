using AgendaPro.Domain.Entities;

namespace AgendaPro.Application.Interfaces
{
    public interface ITarefaRepository : IBaseRepository<Tarefa>
    {
        Task<Tarefa> GetTarefaByEventoId(Guid eventoId);
        Task<Tarefa> GetTarefaById(Guid id);
    }
}
