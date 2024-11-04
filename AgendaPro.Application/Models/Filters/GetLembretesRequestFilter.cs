namespace AgendaPro.Application.Models.Filters
{
    public class GetLembretesRequestFilter : BaseRequestFilter
    {
        public string? Descricao { get; set; }
        public DateTime? HoraLembrete { get; set; }
    }
}
