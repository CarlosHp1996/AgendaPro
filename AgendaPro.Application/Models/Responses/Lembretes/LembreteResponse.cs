namespace AgendaPro.Application.Models.Responses.Lembretes
{
    public class LembreteResponse
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime HoraLembrete { get; set; }
    }
}
