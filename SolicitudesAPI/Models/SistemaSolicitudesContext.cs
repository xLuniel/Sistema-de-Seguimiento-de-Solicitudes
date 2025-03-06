using System;
using System.Collections.Generic;
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

    public virtual DbSet<TestExpediente> TestExpedientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TestExpediente>(entity =>
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<SolicitudesShared.TestExpedienteDTO> TestExpedienteDTO { get; set; } = default!;
}
