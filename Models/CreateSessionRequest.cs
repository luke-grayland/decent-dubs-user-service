using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class CreateSessionRequest
{
    [JsonPropertyName("walletId")]
    public string? WalletId { get; set; }
}