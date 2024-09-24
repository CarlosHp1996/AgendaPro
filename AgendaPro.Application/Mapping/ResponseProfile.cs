using AgendaPro.Application.Models.Responses.Eventos;
using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Application.Models.Responses.Tarefas;
using AgendaPro.Domain.Entities;
using AutoMapper;

namespace AgendaPro.Application.Mapping
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Evento, EventoResponse>();
            CreateMap<Evento, EventoByIdResponse>();
            CreateMap<Tarefa, CreateTarefaResponse>(); 
            CreateMap<Lembrete, CreateLembreteResponse>();
            CreateMap<Lembrete, LembreteResponse>();
            CreateMap<Tarefa, TarefaResponse>();
        }
    }
}
