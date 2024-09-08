using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class CreateUserResponse
{
    [JsonPropertyName("walletID")]
    public string WalletID { get; set; }
}