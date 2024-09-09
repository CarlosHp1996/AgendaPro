namespace AgendaPro.Domain.Entities
{
    public class Evento
    {
        public int Id { get; set; }
        public string Titulo{ get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
        public List<Lembrete> Reminders { get; set; } = new List<Lembrete>();
    }
}
