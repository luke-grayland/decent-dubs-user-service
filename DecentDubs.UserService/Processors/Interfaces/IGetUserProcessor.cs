using DecentDubs.UserService.Models;

namespace DecentDubs.UserService.Processors.Interfaces;

public interface IGetUserProcessor
{
    GetUserResponse Process(string walletId);
}