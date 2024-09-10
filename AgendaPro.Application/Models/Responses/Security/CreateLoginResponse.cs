
namespace AgendaPro.Application.Models.Responses.Security
{
    public class CreateLoginResponse
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string Token { get; set; }
        public string Mensagem { get; set; }
    }
}
