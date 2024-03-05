
using CommonTools;
using ConfigurationManagementService;
using DatabaseManagementService;
using FileManagerService;
using Serilog;
using UserManagerService;

namespace JanetAi.Core;

public class JanetAi
{
    public CommonTools.ToolService ToolService { get; set; }
    public ConfigurationManagementService.ConfigurationService ConfigurationService { get; set; }
    public DatabaseManagementService.DatabaseService DatabaseService { get; set; }
    public FileManagerService.FileManagerService FileManagerService { get; set; }
    public UserManagerService.UserService UserService { get; set; }
    
    public JanetAi()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(FilePathService.GetLogFile(), rollingInterval: RollingInterval.Day)
            .CreateLogger();
        
        ToolService = new ToolService(Log.Logger);
        ConfigurationService = new ConfigurationService(Log.Logger);
        DatabaseService = new DatabaseService(Log.Logger);
        FileManagerService = new FileManagerService.FileManagerService(Log.Logger);
        UserService = new UserService(Log.Logger);
        
        Log.Information("JanetAi initialized.");
        Log.Information(FilePathService.GetAppDataFolder());
        
    }
}