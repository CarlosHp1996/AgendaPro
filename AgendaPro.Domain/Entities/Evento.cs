using AgendaPro.Domain.Entities.Security;

namespace AgendaPro.Domain.Entities
{
    public class Evento
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
        public Guid UsuarioId { get; set; }
        public AspNetUsers Usuario { get; set; }
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
        public List<Lembrete> Lembretes { get; set; } = new List<Lembrete>();
    }
}
