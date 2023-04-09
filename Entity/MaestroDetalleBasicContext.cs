using System;
using System.Collections.Generic;
using MasterDetailsBasics.Models;
using Microsoft.EntityFrameworkCore;

namespace MasterDetailsBasics.Entity;

public partial class MaestroDetalleBasicContext : DbContext
{
    public MaestroDetalleBasicContext()
    {
    }

    public MaestroDetalleBasicContext(DbContextOptions<MaestroDetalleBasicContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<SalesDetail> SalesDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__Sales__BC1240BDBC43F3BA");

            entity.Property(e => e.BusinessName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("businessName");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Overall)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("overall");
        });

        modelBuilder.Entity<SalesDetail>(entity =>
        {
            entity.HasKey(e => e.IdSalesDetails).HasName("PK__SalesDet__F75DCFDE98D079CA");

            entity.Property(e => e.Overall)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("overall");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Product)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.SalesDetails)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__SalesDeta__IdVen__267ABA7A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
