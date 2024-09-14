using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories.Interfaces;
using DecentDubs.UserService.Utilities.Interfaces;

namespace DecentDubs.UserService.Processors;

public class GetUserProcessor(IUserRepository userRepository, ISanitiser sanitiser) : IGetUserProcessor
{
    public GetUserResponse Process(string walletId)
    {
        if (string.IsNullOrEmpty(walletId))
            throw new Exception("Unable to get Wallet ID from request query parameter");

        var user = userRepository.GetUser(sanitiser.Sanitise(walletId) ?? "");

        return new GetUserResponse()
        {
            User = user
        };
    }
}