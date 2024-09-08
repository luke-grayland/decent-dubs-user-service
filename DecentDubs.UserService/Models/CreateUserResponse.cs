using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class CreateUserResponse
{
    [JsonPropertyName("walletId")]
    public string WalletId { get; set; }
}