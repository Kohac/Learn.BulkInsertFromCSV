using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Learn.BulkInsertFromCSV.Entities;

namespace Learn.BulkInsertFromCSV.Context;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MockingTable> MockingTables { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MockingTable>(entity =>
        {
            entity.ToTable("MockingTable");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Email).HasMaxLength(250);

            entity.Property(e => e.FirstName).HasMaxLength(250);

            entity.Property(e => e.Gender).HasMaxLength(20);

            entity.Property(e => e.IpAddress).HasMaxLength(200);

            entity.Property(e => e.LastName).HasMaxLength(250);

            entity.Property(e => e.PhoneNumber).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
