using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Piloto_Buscarini.Models;

public partial class PilotoBuscariniDbmContext : DbContext
{
    public PilotoBuscariniDbmContext()
    {
    }

    public PilotoBuscariniDbmContext(DbContextOptions<PilotoBuscariniDbmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Nacionalidad> Nacionalidads { get; set; }

    public virtual DbSet<Piloto> Pilotos { get; set; }

    public virtual DbSet<Sexo> Sexos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PilotoBuscariniDBM;Trusted_Connection=true; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Nacionalidad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Nacional__3214EC079818A00B");

            entity.ToTable("Nacionalidad");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Piloto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Pilotos__3214EC070BD7CBF8");

            entity.Property(e => e.Apellido).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);

            entity.HasOne(d => d.IdNacionalidadNavigation).WithMany(p => p.Pilotos)
                .HasForeignKey(d => d.IdNacionalidad)
                .HasConstraintName("FK__Pilotos__IdNacio__534D60F1");

            entity.HasOne(d => d.IdSexoNavigation).WithMany(p => p.Pilotos)
                .HasForeignKey(d => d.IdSexo)
                .HasConstraintName("FK__Pilotos__IdSexo__52593CB8");
        });

        modelBuilder.Entity<Sexo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sexo__3213E83F72124A21");

            entity.ToTable("Sexo");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Sexo1)
                .HasMaxLength(20)
                .HasColumnName("sexo");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoginAut__3213E83F6A75A0AD");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(50)
                .HasColumnName("contraseña");
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
