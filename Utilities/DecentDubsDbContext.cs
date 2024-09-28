using DecentDubs.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace DecentDubs.UserService.Utilities;

public class DecentDubsDbContext(DbContextOptions<DecentDubsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<UserSession> UserSessions { get; set; }
    public DbSet<SocialMediaType> SocialMediaTypes { get; set; }
    public DbSet<SocialMediaLink> SocialMediaLinks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Config_UserSession(ref modelBuilder);
        Config_SocialMediaLink(ref modelBuilder);
    }

    private static void Config_UserSession(ref ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserSession>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(us => us.WalletId)
            .HasPrincipalKey(u => u.WalletId);
    }
    
    private static void Config_SocialMediaLink(ref ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SocialMediaLink>()
            .HasKey(sml => new { sml.WalletId, sml.SocialMediaTypeId });
        
        modelBuilder.Entity<SocialMediaLink>()
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(sml => sml.WalletId)
            .HasPrincipalKey(u => u.WalletId);

        modelBuilder.Entity<SocialMediaLink>()
            .HasOne<SocialMediaType>()
            .WithMany()
            .HasForeignKey(sml => sml.SocialMediaTypeId)
            .HasPrincipalKey(smt => smt.Id);
    }
}