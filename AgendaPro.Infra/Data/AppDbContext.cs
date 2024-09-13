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

        public virtual DbSet<Evento> Eventos { get; set; }
        public virtual DbSet<Tarefa> Tarefas { get; set; }
        public virtual DbSet<Lembrete> Lembretes { get; set; }
        public virtual DbSet< AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUsersRefreshToken> AspNetUsersRefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Evento>().ToTable("Evento");
            modelBuilder.Entity<Tarefa>().ToTable("Tarefa");
            modelBuilder.Entity<Lembrete>().ToTable("Lembrete");

            // Configurando o relacionamento entre Evento e Tarefa
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Evento)
                .WithMany(e => e.Tarefas)
                .HasForeignKey(t => t.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configurando o relacionamento entre Evento e Lembrete
            modelBuilder.Entity<Lembrete>()
                .HasOne(l => l.Evento)
                .WithMany(e => e.Lembretes)
                .HasForeignKey(l => l.EventoId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
