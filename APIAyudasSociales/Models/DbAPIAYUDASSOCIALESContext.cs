using System;
using System.Collections.Generic;
using APIAyudasSociales.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace APIAyudasSociales.Models;

public partial class DbAPIAYUDASSOCIALESContext : DbContext
{
    public DbAPIAYUDASSOCIALESContext()
    {
    }

    public DbAPIAYUDASSOCIALESContext(DbContextOptions<DbAPIAYUDASSOCIALESContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asignaciones> Asignaciones { get; set; }

    public virtual DbSet<AyudasSocialesDto> AyudasSociales { get; set; }

    public virtual DbSet<Comuna> Comunas { get; set; }

    public virtual DbSet<Pais> Paises { get; set; }

    public virtual DbSet<Region> Regiones { get; set; }

    public virtual DbSet<Rol> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UserActionLog> UserActionLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Asignaciones>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Asignaci__3214EC074ED56B1E");

            entity.HasIndex(e => new { e.AyudaSocialId, e.UsuarioId, e.Anio }, "UQ__Asignaci__DAB690E6F82A4B25").IsUnique();

            entity.Property(e => e.Activo)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.AyudaSocial).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.AyudaSocialId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asignacio__Ayuda__4AB81AF0");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Asignaciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asignacio__Usuar__4BAC3F29");
        });

        modelBuilder.Entity<AyudasSocialesDto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AyudasSo__3214EC07BD6A871F");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Comuna).WithMany(p => p.AyudasSociales)
                .HasForeignKey(d => d.ComunaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AyudasSoc__Comun__45F365D3");

            entity.HasOne(d => d.Region).WithMany(p => p.AyudasSociales)
               .HasForeignKey(d => d.RegionId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK__AyudasSoc__Regio__4F7CD00D");
        });

        modelBuilder.Entity<Comuna>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comunas__3214EC076C3B78AB");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Region).WithMany(p => p.Comunas)
                .HasForeignKey(d => d.RegionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comunas__RegionI__4316F928");
        });

        modelBuilder.Entity<Pais>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paises__3214EC070ED777DC");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Regiones__3214EC0722AC33D3");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Pais).WithMany(p => p.Regiones)
                .HasForeignKey(d => d.PaisId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Regiones__PaisId__403A8C7D");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC07F75E382F");

            entity.ToTable("Rol");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC078460914E");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasMany(d => d.Roles).WithMany(p => p.Usuarios)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioRol",
                    r => r.HasOne<Rol>().WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioRo__RolId__3B75D760"),
                    l => l.HasOne<Usuario>().WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UsuarioRo__Usuar__3A81B327"),
                    j =>
                    {
                        j.HasKey("UsuarioId", "RolId").HasName("PK__UsuarioR__24AFD79768FE4674");
                        j.ToTable("UsuarioRol");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
