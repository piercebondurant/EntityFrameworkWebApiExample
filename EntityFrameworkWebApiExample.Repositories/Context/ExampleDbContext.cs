using System;
using System.Collections.Generic;
using EntityFrameworkWebApiExample.Repositories.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkWebApiExample.Repositories.Context;

public partial class ExampleDbContext : DbContext
{
    public ExampleDbContext()
    {
    }

    public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ExampleModel> Examples { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExampleModel>(entity =>
        {
            entity.HasKey("ExampleID");
            entity.Property(e => e.ExampleID).HasColumnName("ExampleID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
