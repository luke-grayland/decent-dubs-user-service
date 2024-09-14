using System.Text.RegularExpressions;
using DecentDubs.UserService.Models;
using DecentDubs.UserService.Utilities.Interfaces;

namespace DecentDubs.UserService.Utilities;

public class Sanitiser : ISanitiser
{
    public CreateUserRequest Sanitise(CreateUserRequest request)
    {
        var user = request.User;
        if (user == null) return request; 
        
        user.WalletId = SanitiseForSql(request.User?.WalletId);    
        user.Username = SanitiseForSql(request.User?.Username);    
        user.Email = SanitiseForSql(request.User?.Email);    
        user.ProfilePicUrl = SanitiseForSql(request.User?.ProfilePicUrl);    
        user.Bio = SanitiseForSql(request.User?.Bio);
        user.Country = SanitiseForSql(request.User?.Country);

        request.User = user;
        return request;
    }

    public string? Sanitise(string? inputString) => SanitiseForSql(inputString);
    
    private static string? SanitiseForSql(string? input)
    {
        if (string.IsNullOrEmpty(input)) 
            return input;
        
        const string pattern = @"[^\w@.\-,;:()\s'\p{Sc}]";
        return Regex.Replace(input, pattern, "");
    }
}