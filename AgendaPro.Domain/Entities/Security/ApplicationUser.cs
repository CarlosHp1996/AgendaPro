using Microsoft.AspNetCore.Identity;

namespace AgendaPro.Domain.Entities.Security
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        //public string Nome { get; set; }
        //public DateTime DataCriacao { get; set; }
        //public bool Deletado { get; set; }
        //public int TipoUsuario { get; set; }
        //public string Discriminator { get; set; }

        //public ApplicationUser()
        //{
        //    this.Discriminator = "AspNetUsers";
        //}
    }
}
