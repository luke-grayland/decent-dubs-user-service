using System.ComponentModel.DataAnnotations;

namespace DecentDubs.UserService.Models;

public class SocialMediaType
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string Name { get; set; }
}