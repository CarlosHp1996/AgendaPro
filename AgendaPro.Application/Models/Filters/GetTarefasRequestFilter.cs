namespace AgendaPro.Application.Models.Filters
{
    public class GetTarefasRequestFilter : BaseRequestFilter
    {
        public string? Nome { get; set; }
        public bool? TarefaCompleta { get; set; }
    }
}
