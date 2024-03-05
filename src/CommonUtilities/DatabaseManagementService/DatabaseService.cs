using System.Data.SQLite;
using CommonTools;
using Serilog;

namespace DatabaseManagementService;

public class DatabaseService
{
    public DatabaseService(ILogger p_logger)
    {
        Logger = p_logger;
        Logger.Information("DatabaseService initialized.");

        DatabaseFilePath = FilePathService.GetDatabaseFile();
        ConnectionString = $"Data Source={DatabaseFilePath}";
        InitDatabase();
    }

    private ILogger Logger { get; }

    private string ConnectionString { get; }
    private string DatabaseFilePath { get; }

    private void InitDatabase()
    {
        Logger.Information("Initializing database.");
        if (!File.Exists(DatabaseFilePath))
        {
            Logger.Information($"Database file not found. Creating a new one. {DatabaseFilePath}");
            SQLiteConnection.CreateFile(DatabaseFilePath);
            Logger.Information("Database file created.");
        }
        else
        {
            Logger.Information($"Database file found. {DatabaseFilePath}");
        }

        CreateTable("UserProfile");
        CreateTable("UserCredential");
    }

    public void CreateTable(string p_tableName, bool? p_reset = false)
    {
        Logger.Information("Creating table {TableName}.", p_tableName);

        try
        {
            if (p_reset == true)
                DropTableIfExists(p_tableName);

            var sql = FilePathService.GetSqlFile(p_tableName);

            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = sql;
            command.ExecuteNonQuery();
            Logger.Information("Table {TableName} created.", p_tableName);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Error creating table {TableName}.", p_tableName);
            throw;
        }
    }

    private void DropTableIfExists(string p_tableName)
    {
        Logger.Information("Dropping table {TableName}.", p_tableName);
        try
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = $"DROP TABLE IF EXISTS {p_tableName};";
            command.ExecuteNonQuery();
            Logger.Information("Table {TableName} dropped.", p_tableName);
        }
        catch (Exception e)
        {
            Logger.Error(e, "Error creating table {TableName}.", p_tableName);
            throw;
        }
    }
}