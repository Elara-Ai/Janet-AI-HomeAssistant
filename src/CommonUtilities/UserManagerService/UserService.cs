using CommonTools;
using Serilog;
using UserManagerService.Models;

namespace UserManagerService;

public class UserService
{
    private ILogger Logger { get; set; }
    private UserProfile CurrentUser { get; set; }
    public UserService(ILogger p_logger)
    {
        Logger = p_logger;
        Logger.Information("UserService initialized.");
        CurrentUser = new UserProfile();
    }
    
    public UserProfile GetCurrentUser()
    {
        return CurrentUser;
    }
}