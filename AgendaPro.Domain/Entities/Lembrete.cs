namespace AgendaPro.Domain.Entities
{
    public class Lembrete
    {
        public int Id { get; set; }
        public DateTime ReminderTime { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
