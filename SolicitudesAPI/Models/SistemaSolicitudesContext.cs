using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SolicitudesAPI.Models;

public partial class SistemaSolicitudesContext : DbContext
{
    public SistemaSolicitudesContext()
    {
    }

    public SistemaSolicitudesContext(DbContextOptions<SistemaSolicitudesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Expediente> Expedientes { get; set; }

    public virtual DbSet<ExpedienteDto> ExpedienteDtos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Ignore<Expediente>();
        //modelBuilder.Ignore<ExpedienteDto>();
        //modelBuilder.Ignore<Usuario>();

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuarios__3214EC27AA69A3A2");
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.password)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.Rol)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicitu__3214EC27AA69A3A2");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ContenidoSolicitud).HasMaxLength(4000);
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Folio)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreSolicitante)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SubsanaPrevencionReinicoTramite).HasColumnName("SubsanaPrevencion_ReinicoTramite");
        });

        modelBuilder.Entity<ExpedienteDto>(entity =>
        {
            entity.ToTable("ExpedienteDTO");

            entity.Property(e => e.SubsanaPrevencionReinicoTramite).HasColumnName("SubsanaPrevencion_ReinicoTramite");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
