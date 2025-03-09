using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SolicitudesShared;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Expediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Solicitu__3214EC27AA69A3A2");

            entity.Property(e => e.Id).HasColumnName("ID");
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
            entity.Property(e => e.ContenidoSolicitud)
                .HasColumnType("nvarchar(4000)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<SolicitudesShared.ExpedienteDTO> ExpedienteDTO { get; set; } = default!;
}
