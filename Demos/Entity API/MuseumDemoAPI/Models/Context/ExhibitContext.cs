using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MuseumDemoAPI.Models;

public partial class ExhibitContext : DbContext
{
    public ExhibitContext()
    {
    }

    public ExhibitContext(DbContextOptions<ExhibitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exhibit> Exhibits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MuseumTEST;Integrated Security=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.ToTable("Exhibit");

            entity.Property(e => e.ExhibitId)
                .ValueGeneratedNever()
                .HasColumnName("exhibit_id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
