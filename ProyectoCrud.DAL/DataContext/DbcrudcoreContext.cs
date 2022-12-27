using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using ProyectoCrud.DAL.Models;

namespace ProyectoCrud.DAL.DataContext;

public partial class DbcrudcoreContext : DbContext
{
    public DbcrudcoreContext()
    {
    }

    public DbcrudcoreContext(DbContextOptions<DbcrudcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__usuario__D03DEDCB01A52A5D");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Salario)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("salario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
