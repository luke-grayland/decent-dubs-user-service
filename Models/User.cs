using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class User
{
    [JsonPropertyName("walletId")]
    [Key]
    [MaxLength(50)]
    public string? WalletId { get; set; }
    
    [JsonPropertyName("username")]
    [MaxLength(50)]
    public string? Username { get; set; }

    [JsonPropertyName("created")]
    public DateTime? Created { get; set; }
    
    [JsonPropertyName("isAdmin")]
    public bool IsAdmin { get; set; } = false;

    [MaxLength(80)]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [MaxLength(1000)]
    [JsonPropertyName("profilePicUrl")]
    public string? ProfilePicUrl{ get; set; }

    [JsonPropertyName("verified")]
    public bool Verified { get; set; } = false;
    
    [MaxLength(1000)]
    [JsonPropertyName("bio")]
    public string? Bio { get; set; }
    
    [MaxLength(50)]
    [JsonPropertyName("country")]
    public string? Country { get; set; }
}