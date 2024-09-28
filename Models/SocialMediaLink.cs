using Newtonsoft.Json;

namespace DecentDubs.UserService.Models;

public class SocialMediaLink
{
    public string WalletId { get; set; }
    
    public int SocialMediaTypeId { get; set; }

    [JsonIgnore]
    private User User { get; set; }
    
    [JsonIgnore]
    private SocialMediaType SocialMediaType { get; set; }
}