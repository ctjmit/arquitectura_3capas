using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ProyectoCrud.DAL.Models
{
    public partial class DbpruebaContext : IdentityDbContext<AppUser>
    {
       public DbpruebaContext()
        {
        }

        public DbpruebaContext(DbContextOptions<DbpruebaContext> options)
            : base(options)
        {
        }
       
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<AppUser> Appusers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Usuario>();
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__usuario__3214EC07B178651B");

                entity.ToTable("usuario");

                entity.Property(e => e.Edad).HasColumnName("edad");
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");
                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha");
                entity.Property(e => e.Nombre)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
                entity.Property(e => e.Salario)
                    .HasColumnType("decimal(6, 2)")
                    .HasColumnName("salario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted && 
                e.Metadata.GetProperties().Any(x => x.Name == "EstaBorrado")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["EstaBorrado"] = true;
            }
            return base.SaveChanges();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }

}


