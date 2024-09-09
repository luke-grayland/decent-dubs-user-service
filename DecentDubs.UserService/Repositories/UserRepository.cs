using DecentDubs.UserService.Models;
using DecentDubs.UserService.Repositories.Interfaces;
using DecentDubs.UserService.Utilities;

namespace DecentDubs.UserService.Repositories;

public class UserRepository(DecentDubsDbContext dbContext) : IUserRepository
{
    public void CreateUser(User user)
    {
        dbContext.Add(user);
    }
    
    public User? GetUser(string walletId)
    {
        return dbContext.Users.Find(walletId);
    }
}