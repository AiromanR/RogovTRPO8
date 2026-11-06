using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RogovTRPO8.Models;

public partial class TaskManagerDbContext : DbContext
{
    public TaskManagerDbContext()
    {
    }

    public TaskManagerDbContext(DbContextOptions<TaskManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=TaskManagerDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.OwnerLogin).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(200);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Login, "UQ_Users_Login").IsUnique();

            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .HasDefaultValue("User");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
