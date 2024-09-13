using AgendaPro.Application.Models.Requests.Lembretes;
using AgendaPro.Application.Models.Requests.Tarefas;

namespace AgendaPro.Application.Models.Requests.Eventos
{
    public class CreateEventoRequest
    {
        public string UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
        public List<CreateTarefaRequest> Tarefas { get; set; } = new List<CreateTarefaRequest>();
        public List<CreateLembreteRequest> Lembretes { get; set; } = new List<CreateLembreteRequest>();
    }
}
