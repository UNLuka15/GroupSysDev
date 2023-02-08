using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MuseumDemoAPI.Models;

public partial class RatingLevelContext : DbContext
{
    public RatingLevelContext()
    {
    }

    public RatingLevelContext(DbContextOptions<RatingLevelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<RatingLevel> RatingLevels { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MuseumTEST;Integrated Security=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RatingLevel>(entity =>
        {
            entity.ToTable("RatingLevel");

            entity.Property(e => e.RatingLevelId)
                .ValueGeneratedNever()
                .HasColumnName("rating_level_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Rank).HasColumnName("rank");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
