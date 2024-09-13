namespace AgendaPro.Domain.Entities
{
    public class Lembrete
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraLembrete { get; set; }
        public Guid EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}
