using CommonTools;
using Serilog;

namespace ConfigurationManagementService;

public class ConfigurationService
{
    private ILogger Logger { get; set; }
    public ConfigurationService(ILogger p_logger)
    {
        Logger = p_logger;
        Logger.Information("ConfigurationService initialized.");
    }
}