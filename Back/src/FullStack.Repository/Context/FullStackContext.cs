
using FullStack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FullStack.Repository
{
    public class FullStackContext : DbContext
    {
        public FullStackContext(DbContextOptions<FullStackContext> options): base(options)
        {
            
        }
        public DbSet<Evento> Eventos{get; set;}
        public DbSet<Lote> Lotes{get; set;}
        public DbSet<Palestrante> Palestrantes{get; set;}
        public DbSet<PalestranteEvento> PalestranteEventos{get; set;}
        public DbSet<RedeSocial> RedeSSociaIS{get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PalestranteEvento>()
            .HasKey(PE => new {PE.EventoId, PE.PalestranteId });

            modelBuilder.Entity<Evento>()
            .HasMany(e => e.RedesSociais)
            .WithOne(rs => rs.Evento)
            .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Palestrante>()
            .HasMany(e => e.RedesSociais)
            .WithOne(rs => rs.Palestrante)
            .OnDelete(DeleteBehavior.Cascade);
        }
        
    }
}