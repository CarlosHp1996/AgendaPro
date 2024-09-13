namespace AgendaPro.Application.Models.Responses.Security
{
    public class CreateUsuarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Mensagem { get; set; }
    }
}
