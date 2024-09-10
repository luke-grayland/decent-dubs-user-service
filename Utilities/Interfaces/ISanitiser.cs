using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Utilities.Interfaces;

public interface ISanitiser
{
    CreateUserRequest Sanitise(CreateUserRequest request);
    string? Sanitise(string? inputString);
}