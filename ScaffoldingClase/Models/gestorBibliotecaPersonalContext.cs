using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ScaffoldingClase.Models
{
    public partial class gestorBibliotecaPersonalContext : DbContext
    {
        public gestorBibliotecaPersonalContext()
        {
        }

        public gestorBibliotecaPersonalContext(DbContextOptions<gestorBibliotecaPersonalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GbpAlmCatLibro> GbpAlmCatLibros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("CadenaConexionPostgreSQL"); //esto no se si es asi
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GbpAlmCatLibro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("gbp_alm_cat_libros_pkey");

                entity.ToTable("gbp_alm_cat_libros", "gbp_almacen");

                entity.Property(e => e.IdLibro)
                    .HasColumnName("id_libro")
                    .HasDefaultValueSql("nextval('gbp_alm_cat_libros_id_libro_seq'::regclass)");

                entity.Property(e => e.Autor)
                    .HasColumnType("character varying")
                    .HasColumnName("autor");

                entity.Property(e => e.Edicion).HasColumnName("edicion");

                entity.Property(e => e.Isbn)
                    .HasColumnType("character varying")
                    .HasColumnName("isbn");

                entity.Property(e => e.Titulo)
                    .HasColumnType("character varying")
                    .HasColumnName("titulo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
