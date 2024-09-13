using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Entities;
using AgendaPro.Infra.Data;

namespace AgendaPro.Infra.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
