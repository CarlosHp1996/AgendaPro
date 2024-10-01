using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos
{
    public class DesactiveEventoCommand : IRequest<Result>
    {
        public Guid Id;

        public DesactiveEventoCommand(Guid id)
        {
            Id = id;
        }
    }
}
