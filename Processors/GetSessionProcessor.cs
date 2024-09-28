using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;
using DecentDubs.UserService.Repositories.Interfaces;

namespace DecentDubs.UserService.Processors;

public class GetSessionProcessor(IUserRepository userRepository) : IGetSessionProcessor
{
    public GetSessionResponse Process(string sessionId)
    { 
        var userSession = userRepository.GetUserSession(sessionId);
        
        return new GetSessionResponse()
        {
            UserSession = userSession,
            ActiveSessionFound = userSession != null
        };
    }
}