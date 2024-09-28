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
            Created = user.Created,
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

    public void CreateUserSession(UserSession userSession)
    {
        dbContext.UserSessions.Add(userSession);
        dbContext.SaveChanges();
    }

    public UserSession? GetUserSession(string sessionId)
    {
        return dbContext.UserSessions.FirstOrDefault(x => 
            x.SessionId == sessionId && x.ExpiryDate > DateTime.Now); 
    }
}