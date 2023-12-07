using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace STG.back.Models;

public partial class DbCrudBlazorContext : DbContext
{
    public DbCrudBlazorContext()
    {
    }

    public DbCrudBlazorContext(DbContextOptions<DbCrudBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("PK__Animal__A21A73075A362ECA");

            entity.ToTable("Animal");

            entity.Property(e => e.AnimalId).ValueGeneratedNever();
            entity.Property(e => e.BirthDate).HasColumnType("date");
            entity.Property(e => e.Breed)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Sex)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
