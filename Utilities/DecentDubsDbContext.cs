using DecentDubs.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace DecentDubs.UserService.Utilities;

public class DecentDubsDbContext(DbContextOptions<DecentDubsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    public DbSet<UserSession> UserSessions { get; set; }
}