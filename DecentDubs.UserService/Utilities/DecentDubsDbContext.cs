using DecentDubs.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace DecentDubs.UserService.Utilities;

public class DecentDubsDbContext(DbContextOptions<DecentDubsDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("YourConnectionStringHere");
    // }
}