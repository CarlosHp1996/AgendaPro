using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Eventos
{
    public class DeleteEventoCommand : IRequest<Result>
    {
        public Guid Id;

        public DeleteEventoCommand(Guid id)
        {
            Id = id;
        }
    }
}
