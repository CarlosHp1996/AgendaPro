namespace AgendaPro.Application.Models.Filters
{
    public class GetEventosRequestFilter : BaseRequestFilter
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Local { get; set; }
    }
}
