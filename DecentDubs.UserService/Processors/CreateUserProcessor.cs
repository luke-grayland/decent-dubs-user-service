using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories.Interfaces;

namespace DecentDubs.UserService.Processors;

public class CreateUserProcessor(IUserRepository userRepository) : ICreateUserProcessor
{
    public CreateUserResponse Process(CreateUserRequest request)
    {
        //check if user already has account
        //if not, add user
        
        return new CreateUserResponse()
        {
            WalletId = request.WalletId
        };
    }
}