namespace App.Infrastructure.Data
{
    using App.Domain.Entities;
    // Infrastructure/Data/AppDbContext.cs
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<NoticiaTag> NoticiaTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<Noticia>().ToTable("Noticia");
            modelBuilder.Entity<Tag>().ToTable("Tag");
            modelBuilder.Entity<NoticiaTag>().ToTable("NoticiaTag");

            // Configuração de relacionamentos
            modelBuilder.Entity<Noticia>()
                .HasOne(n => n.Usuario)
                .WithMany(u => u.Noticias)
                .HasForeignKey(n => n.UsuarioId);

            modelBuilder.Entity<NoticiaTag>()
                .HasOne(nt => nt.Noticia)
                .WithMany(n => n.NoticiaTags)
                .HasForeignKey(nt => nt.NoticiaId);

            modelBuilder.Entity<NoticiaTag>()
                .HasOne(nt => nt.Tag)
                .WithMany(t => t.NoticiaTags)
                .HasForeignKey(nt => nt.TagId);
        }
    }

}
