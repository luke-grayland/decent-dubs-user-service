using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Processors.Interfaces;

public interface ICreateUserProcessor
{
    Task<CreateUserResponse> Process(CreateUserRequest request);
}