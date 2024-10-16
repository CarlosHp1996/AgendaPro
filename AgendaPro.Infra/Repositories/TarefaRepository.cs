using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Helpers;
using AgendaPro.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Infra.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Tarefa> GetTarefaByEventoId(Guid eventoId)
        {
            var tarefa = _context.Tarefas
                .Where(x => x.EventoId == eventoId)
                .AsQueryable();

            return await tarefa.FirstOrDefaultAsync();
        }

        public async Task<AsyncOutResult<IEnumerable<Tarefa>, int>> Get(int take, int offset, string sortingProp, bool asc, string? nome, bool? tarefaCompleta)
        {
            // Inicializando a consulta
            var query = _context.Tarefas
                .AsQueryable();

            // Aplicando os filtros
            if (!string.IsNullOrEmpty(nome))
                query = query.Where(p => p.Nome.Contains(nome));

            if (tarefaCompleta.HasValue)
                query = query.Where(p => p.TarefaCompleta == tarefaCompleta);

            if (DataHelpers.CheckExistingProperty<Tarefa>(sortingProp))
                query = query.OrderByDynamic(sortingProp, asc);

            var totalCount = await query.CountAsync();
            var tarefas = await query.Skip(offset).Take(take).ToListAsync();

            return new AsyncOutResult<IEnumerable<Tarefa>, int>(tarefas, totalCount);
        }
    }
}
