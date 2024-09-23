using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories.Interfaces;
using DecentDubs.UserService.Utilities.Interfaces;

namespace DecentDubs.UserService.Processors;

public class CreateUserProcessor(IUserRepository userRepository, ISanitiser sanitiser) : ICreateUserProcessor
{
    public CreateUserResponse Process(CreateUserRequest request)
    {
        if (request.User == null) throw new Exception("User missing in CreateUserRequest");
        var cleanRequest = sanitiser.Sanitise(request);
        var walletId = cleanRequest?.User?.WalletId ?? throw new Exception("Wallet ID missing in request");
        
        if (userRepository.GetUser(walletId) != null)
            throw new BusinessException($"Existing user with found with wallet ID: {request?.User?.WalletId}");
        
        userRepository.CreateUser(cleanRequest.User);
        
        return new CreateUserResponse()
        {
            User = cleanRequest.User
        };
    }
}