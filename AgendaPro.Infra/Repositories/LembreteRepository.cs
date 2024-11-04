using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;
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

        public async Task<AsyncOutResult<IEnumerable<Lembrete>, int>> Get(int take, int offset, string sortingProp, bool asc, string? descricao, DateTime? horaLembrete)
        {
            // Inicializando a consulta
            var query = _context.Lembretes
                .AsQueryable();

            // Aplicando os filtros
            if (!string.IsNullOrEmpty(descricao))
                query = query.Where(p => p.Descricao.Contains(descricao));

            if (horaLembrete.HasValue)
                query = query.Where(p => p.HoraLembrete == horaLembrete);

            if (DataHelpers.CheckExistingProperty<Lembrete>(sortingProp))
                query = query.OrderByDynamic(sortingProp, asc);

            var totalCount = await query.CountAsync();
            var lembretes = await query.Skip(offset).Take(take).ToListAsync();

            return new AsyncOutResult<IEnumerable<Lembrete>, int>(lembretes, totalCount);
        }
    }
}
