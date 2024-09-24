using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Application.Models.Responses.Tarefas;

namespace AgendaPro.Application.Models.Responses.Eventos
{
    public class EventoResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
        public int MyProperty { get; set; }
        public List<TarefaResponse> Tarefas { get; set; } = new List<TarefaResponse>();
        public List<LembreteResponse> Lembretes { get; set; } = new List<LembreteResponse>();
    }
}
