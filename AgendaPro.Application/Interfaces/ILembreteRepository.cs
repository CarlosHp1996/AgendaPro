using AgendaPro.Domain.Entities;

namespace AgendaPro.Application.Interfaces
{
    public interface ILembreteRepository : IBaseRepository<Lembrete>
    {
        Task<Lembrete> GetLembreteByEventoId(Guid eventoId);
    }
}
