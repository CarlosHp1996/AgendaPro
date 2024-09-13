namespace AgendaPro.Application.Models.Requests.Lembretes
{
    public class CreateLembreteRequest
    {
        public string Descricao { get; set; }
        public DateTime HoraLembrete { get; set; }
    }
}
