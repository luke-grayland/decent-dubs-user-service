using System.ComponentModel.DataAnnotations;

namespace DecentDubs.UserService.Models;

public class UserSession
{
    [Key]
    [MaxLength(50)]
    public string SessionId { get; set; } = null!;

    [MaxLength(50)]
    public string WalletId { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }
}
