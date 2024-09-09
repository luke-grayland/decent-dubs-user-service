using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories.Interfaces;

namespace DecentDubs.UserService.Processors;

public class GetUserProcessor(IUserRepository userRepository) : IGetUserProcessor
{
    public GetUserResponse Process(string walletId)
    {
        var user = userRepository.GetUser(walletId);
        
        return new GetUserResponse();
    }
}