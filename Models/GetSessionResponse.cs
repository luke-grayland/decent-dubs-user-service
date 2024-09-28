using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class GetSessionResponse
{
    [JsonPropertyName("userSession")]
    public UserSession? UserSession { get; set; }

    [JsonPropertyName("activeSessionFound")]
    public bool ActiveSessionFound { get; set; }
}