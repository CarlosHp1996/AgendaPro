using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos
{
    public class ActivateEventoCommand : IRequest<Result>
    {
        public Guid Id;

        public ActivateEventoCommand(Guid id)
        {
            Id = id;
        }
    }
}
