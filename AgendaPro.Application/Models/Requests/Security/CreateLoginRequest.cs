namespace AgendaPro.Application.Models.Requests.Security
{
    public class CreateLoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
