using Serilog;

namespace CommonTools;

public class ToolService
{
    private ILogger Logger { get; set; }
    public ToolService(ILogger p_logger)
    {
        Logger = p_logger;
        Logger.Information("ToolService initialized.");
    }
}