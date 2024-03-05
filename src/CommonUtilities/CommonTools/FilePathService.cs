namespace CommonTools;

public static class FilePathService
{
    public static string GetAppName()
    {
        return AppConstants.AppName;
    }
    public static string GetProjectRoot()
    {
        return AppConstants.ProjectRoot;
    }
    public static string GetAssetsFolder()
    {
        return AppConstants.ProjectFolders.Assets;
    }
    public static string GetDatabaseFolder()
    {
        return AppConstants.ProjectFolders.Database;
    }
    public static string GetDocsFolder()
    {
        return AppConstants.ProjectFolders.Docs;
    }
    public static string GetScriptsFolder()
    {
        return AppConstants.ProjectFolders.Scripts;
    }
    public static string GetSqlFolder()
    {
        return AppConstants.ProjectFolders.Sql;
    }
    public static string GetSecretsFolder()
    {
        return AppConstants.ProjectFolders.Secrets;
    }
    public static string GetSourceFolder()
    {
        return AppConstants.ProjectFolders.Source;
    }
    
    public static string GetAppDataFolder()
    {
        return AppConstants.ProgramData.AppData;
    }
    public static string GetLogsFolder()
    {
        return AppConstants.ProgramData.Logs;
    }
    public static string GetConfigFolder()
    {
        return AppConstants.ProgramData.Config;
    }
    public static string GetTempFolder()
    {
        return AppConstants.ProgramData.Temp;
    }
    
    public static string GetLogFile()
    {
        return AppConstants.ProgramFiles.Log;
    }
    public static string GetClientConfigFile()
    {
        return AppConstants.ProgramFiles.ClientConfig;
    }
    public static string GetAppConfigFile()
    {
        return AppConstants.ProgramFiles.AppConfig;
    }
    public static string GetDatabaseFile()
    {
        return AppConstants.ProgramFiles.DatabaseFile;
    }

    public static string GetSqlFile(string p_sqlFileName)
    {
        var filePath = Path.Combine(GetSqlFolder(), p_sqlFileName) + ".sql";
        if (File.Exists(filePath))
            return File.ReadAllText(filePath);
        throw new FileNotFoundException($"Sql file not found: {filePath}");
    }
}