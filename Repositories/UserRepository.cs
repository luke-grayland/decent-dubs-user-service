using DecentDubs.UserService.Models;
using DecentDubs.UserService.Repositories.Interfaces;
using DecentDubs.UserService.Utilities;

namespace DecentDubs.UserService.Repositories;

public class UserRepository(DecentDubsDbContext dbContext) : IUserRepository
{
    public void CreateUser(User user)
    {
        dbContext.Add(new User()
        {
            WalletId = user.WalletId,
            Username = user.Username,
            Created = DateTime.Now,
            IsAdmin = false,
            Email = user.Email,
            ProfilePicUrl = user.ProfilePicUrl,
            Verified = false,
            Bio = user.Bio,
            Country = user.Country
        });
        
        dbContext.SaveChanges();
    }
    
    public User? GetUser(string walletId)
    {
        return dbContext.Users.Find(walletId);
    }
}