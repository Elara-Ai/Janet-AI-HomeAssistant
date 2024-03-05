using CommonTools;
using Serilog;

namespace FileManagerService;

public class FileManagerService
{
    private ILogger Logger { get; set; }

    public FileManagerService(ILogger p_logger)
    {
        Logger = p_logger;
        Logger.Information("FileManagerService initialized.");
        
        SmartCreateFolder(FilePathService.GetAppDataFolder());
        SmartCreateFolder(FilePathService.GetLogsFolder());
        SmartCreateFolder(FilePathService.GetConfigFolder());
        SmartCreateFolder(FilePathService.GetTempFolder());
        
        SmartCreateFile(FilePathService.GetLogFile());
        SmartCreateFile(FilePathService.GetAppConfigFile());
        SmartCreateFile(FilePathService.GetClientConfigFile()); }

    private void SmartCreateFile(string p_filePath, string? p_content = null)
    {
        if (File.Exists(p_filePath))
        {
            Logger.Information($"Skipping file: {p_filePath}");
            return;
        }
        Logger.Information($"Creating file: {p_filePath}");
        File.Create(p_filePath);
        Logger.Information("File created.");
        if (!string.IsNullOrEmpty(p_content))
        {
            Logger.Information($"Adding Content to file: {p_filePath}");
            File.WriteAllText(p_filePath, p_content);
            Logger.Information("Content added.");
        }

    }
    
    private void SmartCreateFolder(string p_folderPath)
    {
        if(!Directory.Exists(p_folderPath))
        {
            Logger.Information($"Creating folder: {p_folderPath}");
            Directory.CreateDirectory(p_folderPath);
            Logger.Information("Folder created.");
        }
        else
        {
            Logger.Information($"Skipping folder: {p_folderPath}");
        }
    }
    
}