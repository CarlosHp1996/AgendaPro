using AgendaPro.Application.Models.Responses.Lembretes;
using AgendaPro.Domain.Helpers;
using MediatR;

namespace AgendaPro.Application.Queries.Lembretes
{
    public class GetLembreteByIdQuery : IRequest<Result<LembreteResponse>>
    {
        public Guid Id { get; set; }

        public GetLembreteByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
