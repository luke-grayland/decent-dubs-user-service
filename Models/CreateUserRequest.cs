using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class CreateUserRequest
{
    [JsonPropertyName("user")]
    public User? User { get; set; }
}