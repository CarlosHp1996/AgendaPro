namespace AgendaPro.Application.Models.Requests.Security
{
    public class CreateUsuarioRequest
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
    }
}
