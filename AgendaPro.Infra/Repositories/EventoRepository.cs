using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;
using AgendaPro.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Infra.Repositories
{
    public class EventoRepository : BaseRepository<Evento>, IEventoRepository
    {
        private readonly AppDbContext _context;

        public EventoRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AsyncOutResult<IEnumerable<Evento>, int>> Get(int take, int offset, string sortingProp, bool asc, string? titulo, string? descricao, DateTime? dataInicio, DateTime? dataFim, string? local)
        {
            // Inicializando a consulta
            var query = _context.Eventos
                .Include(x => x.Tarefas)
                .Include(x => x.Lembretes)
                .AsQueryable();

            // Aplicando os filtros
            if (!string.IsNullOrEmpty(titulo))
                query = query.Where(p => p.Titulo.Contains(titulo));

            if (!string.IsNullOrEmpty(descricao))
                query = query.Where(p => p.Descricao.Contains(descricao));

            if (dataInicio.HasValue)
                query = query.Where(p => p.DataInicio >= dataInicio.Value);

            if (dataFim.HasValue)
                query = query.Where(p => p.DataFim <= dataFim.Value);

            if (!string.IsNullOrEmpty(local))
                query = query.Where(p => p.Local.Contains(local));

            if (DataHelpers.CheckExistingProperty<Evento>(sortingProp))
                query = query.OrderByDynamic(sortingProp, asc);

            var totalCount = await query.CountAsync();
            var eventos = await query.Skip(offset).Take(take).ToListAsync();

            return new AsyncOutResult<IEnumerable<Evento>, int>(eventos, totalCount);
        }
    }
}
