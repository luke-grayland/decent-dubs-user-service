using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class CreateUserResponse
{
    [JsonPropertyName("user")]
    public User? User { get; set; }
}