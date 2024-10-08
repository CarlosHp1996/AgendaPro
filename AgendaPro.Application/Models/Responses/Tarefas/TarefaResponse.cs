namespace AgendaPro.Application.Models.Responses.Tarefas
{
    public class TarefaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool TarefaCompleta { get; set; }
    }
}
