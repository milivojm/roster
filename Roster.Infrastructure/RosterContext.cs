using Microsoft.EntityFrameworkCore;
using Roster.Core;

namespace Roster.Infrastructure;

public class RosterContext : DbContext
{
    public RosterContext(DbContextOptions<RosterContext> options) : base(options)
    {

    }

    public DbSet<MembershipApplication> MembershipApplications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MembershipApplication>(entityTypeBuilder =>
        {
            entityTypeBuilder.HasKey(ma => ma.Username);
            entityTypeBuilder.Property<string>("_hashedPassword")
                             .HasColumnName("HashedPassword")
                             .IsRequired();
        });
    }
}