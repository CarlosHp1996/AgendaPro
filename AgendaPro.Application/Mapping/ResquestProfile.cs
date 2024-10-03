using AgendaPro.Application.Models.Requests.Eventos;
using AgendaPro.Application.Models.Requests.Tarefas;
using AgendaPro.Domain.Entities;
using AutoMapper;

namespace AgendaPro.Application.Mapping
{
    public class ResquestProfile : Profile
    {
        public ResquestProfile() 
        {
            CreateMap<CreateEventoRequest, Evento>();
            CreateMap<UpdateEventoRequest, Evento>();
            CreateMap<CreateTarefaRequest, Tarefa>();
        }
    }
}
