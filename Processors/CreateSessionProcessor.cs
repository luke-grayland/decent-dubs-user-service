using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories.Interfaces;

namespace DecentDubs.UserService.Processors;

public class CreateSessionProcessor(IUserRepository userRepository) : ICreateSessionProcessor
{
    public UserSession Process(CreateSessionRequest request)
    {
        if (string.IsNullOrEmpty(request.WalletId))
            throw new Exception("Wallet ID not found in request");
        
        var userSession = new UserSession()
        {
            SessionId = Guid.NewGuid().ToString(),
            WalletId = request.WalletId,
            CreatedDate = DateTime.Now,
            ExpiryDate = DateTime.Now.AddDays(1)
        };
        
        userRepository.CreateUserSession(userSession);

        return userSession;
    }
}