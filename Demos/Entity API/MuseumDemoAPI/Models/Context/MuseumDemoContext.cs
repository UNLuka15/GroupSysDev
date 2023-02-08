using Microsoft.EntityFrameworkCore;

namespace MuseumDemoAPI.Models;

public partial class AccountContext : DbContext
{
    public AccountContext()
    {
    }

    public AccountContext(DbContextOptions<AccountContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MuseumTEST;Integrated Security=true;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Account");

            entity.Property(e => e.AccountId)
                .ValueGeneratedOnAdd()
                .HasColumnName("account_id");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
