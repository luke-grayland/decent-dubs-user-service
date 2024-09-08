using DecentDubs.UserService.Models;
using DecentDubs.UserService.Processors.Interfaces;

namespace DecentDubs.UserService.Processors;

public class CreateUserProcessor : ICreateUserProcessor
{
    public CreateUserResponse Process(CreateUserRequest request)
    {
        return new CreateUserResponse()
        {
            WalletID = request.WalletID
        };
    }
}