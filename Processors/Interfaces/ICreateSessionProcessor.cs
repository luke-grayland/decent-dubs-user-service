using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Processors.Interfaces;

public interface ICreateSessionProcessor
{
    UserSession Process(CreateSessionRequest request);
}