namespace AgendaPro.Application.Models.Requests.Lembretes
{
    public class CreateLembreteRequest
    {
        public Guid EventoId { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraLembrete { get; set; }
    }
}
