using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace XSJC.AppMVC.Models;

public partial class XjscContext : DbContext
{
    public XjscContext()
    {
    }

    public XjscContext(DbContextOptions<XjscContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bicicleta> Bicicletas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=XIO;Database=XJSC;Trusted_Connection=True; Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bicicleta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Biciclet__3214EC0766D620AD");

            entity.Property(e => e.DescripcionDelProblema)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Descripcion_del_problema");
            entity.Property(e => e.Modelo)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
