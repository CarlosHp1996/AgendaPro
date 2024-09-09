namespace AgendaPro.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Armazenar hash da senha
        public List<Evento> Eventos { get; set; } = new List<Evento>();
    }
}
