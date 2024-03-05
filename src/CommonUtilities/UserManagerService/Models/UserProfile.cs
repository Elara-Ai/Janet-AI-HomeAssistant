using System.ComponentModel.DataAnnotations;

namespace UserManagerService.Models;

public class UserProfile : EntityBase
{
    [Required]
    public string Username { get; set; }

    private readonly List<UserCredential> _userCredentials;
    private UserCredential CurrentCredential { get; set; }
    
    public UserProfile()
    {
        Username = string.Empty;
        _userCredentials = LoadUserCredentials();
        if(_userCredentials is null)
            _userCredentials = new List<UserCredential>(){new UserCredential()};
        else
            CurrentCredential = _userCredentials.MaxBy(p_uc => p_uc.Created) 
                ?? new UserCredential();
    }
    
    public void AddCredential(UserCredential p_credential)
    {
        _userCredentials.Add(p_credential);
    }
    
    private List<UserCredential> LoadUserCredentials()
    {
        return null;
        return _userCredentials
            .Where(p_uc => p_uc.UserProfileUid == Uid)
            .OrderByDescending(uc => uc.Created)
            .ToList();
    }
    
    
    
    
}