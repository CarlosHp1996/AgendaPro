using AgendaPro.Domain.Entities;
using AgendaPro.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgendaPro.Infra.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }
        public virtual DbSet<Lembrete> Lembretes { get; set; }
        public virtual DbSet< AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUsersRefreshToken> AspNetUsersRefreshToken { get; set; }
    }
}
