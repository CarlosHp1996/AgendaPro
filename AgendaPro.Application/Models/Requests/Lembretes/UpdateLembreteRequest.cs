namespace AgendaPro.Application.Models.Requests.Lembretes
{
    public class UpdateLembreteRequest
    {
        public string Descricao { get; set; }
        public DateTime HoraLembrete { get; set; }
    }
}
