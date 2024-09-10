using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Processors.Interfaces;

public interface ICreateUserProcessor
{
    CreateUserResponse Process(CreateUserRequest request);
}