using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DecentDubs.UserService.Models;

public class UserSession
{
    [Key]
    [MaxLength(50)]
    public string SessionId { get; set; } = null!;

    [MaxLength(50)]
    public string WalletId { get; set; } = null!;

    public DateTime CreatedDate { get; set; }
    
    public DateTime ExpiryDate { get; set; }

    [JsonIgnore]
    private User User { get; set; }
}
