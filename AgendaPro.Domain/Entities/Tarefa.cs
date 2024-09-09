namespace AgendaPro.Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool IsCompleted { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
