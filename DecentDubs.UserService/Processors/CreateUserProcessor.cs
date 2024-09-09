using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories.Interfaces;

namespace DecentDubs.UserService.Processors;

public class CreateUserProcessor(IUserRepository userRepository) : ICreateUserProcessor
{
    public async Task<CreateUserResponse> Process(CreateUserRequest request)
    {
        if (userRepository.GetUser(request.User.WalletId ?? "") != null)
            throw new Exception($"Existing user with found with wallet ID: {request.User.WalletId}");
            
        request.User.Created = DateTime.UtcNow;
        userRepository.CreateUser(request.User);
        
        return new CreateUserResponse()
        {
            WalletId = request.User.WalletId
        };
    }
}