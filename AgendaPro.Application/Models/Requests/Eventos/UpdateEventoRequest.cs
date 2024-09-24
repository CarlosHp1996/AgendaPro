using AgendaPro.Application.Models.Requests.Lembretes;
using AgendaPro.Application.Models.Requests.Tarefas;

namespace AgendaPro.Application.Models.Requests.Eventos
{
    public class UpdateEventoRequest
    {
        public Guid EventoId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
        public List<UpdateTarefaRequest> Tarefas { get; set; } = new List<UpdateTarefaRequest>();
        public List<UpdateLembreteRequest> Lembretes { get; set; } = new List<UpdateLembreteRequest>();
    }
}
