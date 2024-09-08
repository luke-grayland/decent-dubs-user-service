using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Repositories.Interfaces;

public interface IUserRepository
{
    void CreateUser();
    User GetUser();
}