using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RogovTRPO8.Models;

public partial class RogovDbContext : DbContext
{
    public RogovDbContext()
    {
    }

    public RogovDbContext(DbContextOptions<RogovDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=sql.ects;Database=RogovDB;User Id=student_00;Password=student_00;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
