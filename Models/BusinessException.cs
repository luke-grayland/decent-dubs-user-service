namespace DecentDubs.UserService.Models;

public class BusinessException(string errorMessage) : Exception(errorMessage)
{
}