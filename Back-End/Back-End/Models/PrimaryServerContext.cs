using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Back_End.Models;

public partial class PrimaryServerContext : DbContext
{
    public PrimaryServerContext()
    {
    }

    public PrimaryServerContext(DbContextOptions<PrimaryServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<OwnerDashBoard> OwnerDashBoards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Optionally configure the context here if not using dependency injection.
        // Example:
        // if (!optionsBuilder.IsConfigured)
        // {
        //     optionsBuilder.UseSqlServer("YourConnectionString");
        // }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OwnerDashBoard>(entity =>
        {
            entity.ToTable("OwnerDashBoard");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Department).HasMaxLength(50);
            entity.Property(e => e.EmployeeId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
