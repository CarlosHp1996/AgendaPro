using AgendaPro.Application.Interfaces;
using AgendaPro.Domain.Entities;
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
    }
}
