namespace AgendaPro.Application.Models.Requests.Tarefas
{
    public class CreateTarefaRequest
    {
        public string Nome { get; set; }
        public bool TarefaCompleta { get; set; }
    }
}
