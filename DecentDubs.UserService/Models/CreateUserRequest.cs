using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class CreateUserRequest
{
    [JsonPropertyName("walletID")]
    public string WalletID { get; set; }
}