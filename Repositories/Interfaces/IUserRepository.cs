using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Repositories.Interfaces;

public interface IUserRepository
{
    void CreateUser(User user);
    User? GetUser(string walletId);
    void CreateUserSession(UserSession userSession);
    UserSession? GetUserSession(string sessionId);
}