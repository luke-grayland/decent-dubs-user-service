using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Processors.Interfaces;

public interface IGetSessionProcessor
{
    GetSessionResponse Process(string sessionId);
}