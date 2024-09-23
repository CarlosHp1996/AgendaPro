namespace AgendaPro.Application.Models.Responses.Eventos
{
    public class EventoByIdResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Local { get; set; }
    }
}
