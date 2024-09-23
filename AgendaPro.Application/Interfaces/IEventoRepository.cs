using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;

namespace AgendaPro.Application.Interfaces
{
    public interface IEventoRepository : IBaseRepository<Evento>
    {
        Task<AsyncOutResult<IEnumerable<Evento>, int>> Get(int take, int offset, string sortingPro, bool asc, string? titulo, string? descricao, DateTime? dataInicio, DateTime? dataFim, string? local);
        Task<Evento> GetEventoById(Guid id);
    }
}
