namespace CommonTools;

internal abstract class AppConstants
{
    internal static readonly string AppName = "JanetAi";
    internal static readonly string ProjectRoot = @"D:\Janet-AI-HomeAssistant";
    
    internal class ProjectFolders
    {
        internal static string Assets = Path.Combine(ProjectRoot, "assets");
        internal static string Database = Path.Combine(ProjectRoot, "database");
        internal static string Docs = Path.Combine(ProjectRoot, "docs");
        internal static string Scripts = Path.Combine(ProjectRoot, "scripts");
        internal static readonly string Sql = Path.Combine(ProjectRoot, "sql");
        internal static string Secrets = Path.Combine(ProjectRoot, "secrets");
        internal static string Source = Path.Combine(ProjectRoot, "src");
    }

    internal class ProgramData
    {
        internal static readonly string AppData =
            $@"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\{AppName}\";

        internal static readonly string Logs = Path.Combine(AppData, "logs");
        internal static readonly string Config = Path.Combine(AppData, "config");
        internal static readonly string Temp = Path.Combine(AppData, "temp");
    }

    internal class ProgramFiles
        {
            internal static readonly string Log = Path.Combine(ProgramData.Logs, $"{AppName}.log");
            internal static string ClientConfig = Path.Combine(ProgramData.Config, $"ClientConfig-{AppName}.json");
            internal static string AppConfig = Path.Combine(ProgramData.Config, $"AppConfig-{AppName}.json");
            internal static string DatabaseFile = Path.Combine(ProjectFolders.Database, $"{AppName}.sqlite");
        }
    

}