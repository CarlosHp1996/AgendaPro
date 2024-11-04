using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Commands.Lembretes
{
    public class DeleteLembreteCommand : IRequest<Result>
    {
        public Guid Id;

        public DeleteLembreteCommand(Guid id)
        {
            Id = id;
        }
    }
}
