namespace AgendaPro.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool TarefaCompleta { get; set; }
        public Guid EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
