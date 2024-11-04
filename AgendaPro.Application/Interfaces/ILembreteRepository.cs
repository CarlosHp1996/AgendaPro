using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;

namespace AgendaPro.Application.Interfaces
{
    public interface ILembreteRepository : IBaseRepository<Lembrete>
    {
        Task<Lembrete> GetLembreteByEventoId(Guid eventoId);
        Task<AsyncOutResult<IEnumerable<Lembrete>, int>> Get(int take, int offset, string sortingProp, bool asc, string? descricao, DateTime? horaLembrete);
    }
}
