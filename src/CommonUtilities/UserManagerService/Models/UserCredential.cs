using System.ComponentModel.DataAnnotations;

namespace UserManagerService.Models;

public class UserCredential : EntityBase
{
    public UserCredential()
    {
        UserProfileUid = Guid.Empty;
        Password = string.Empty;
        Salt = string.Empty;
        Hash = string.Empty;
    }
 
    public Guid UserProfileUid { get; set; }
    public TimestampAttribute Created { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Hash { get; set; }
}