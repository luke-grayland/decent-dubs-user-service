using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class CreateUserRequest
{
    [JsonPropertyName("walletId")]
    public string WalletId { get; set; }
}