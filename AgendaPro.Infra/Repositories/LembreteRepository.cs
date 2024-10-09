using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Entities;
using AgendaPro.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Infra.Repositories
{
    public class LembreteRepository : BaseRepository<Lembrete>, ILembreteRepository
    {
        public readonly AppDbContext _context;

        public LembreteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Lembrete> GetLembreteByEventoId(Guid eventoId)
        {
            var lembrete = _context.Lembretes
                .Where(x => x.EventoId == eventoId)
                .AsQueryable();

            return await lembrete.FirstOrDefaultAsync();
        }   
    }
}
