using System.Data;
using System.Data.SQLite;

namespace Server.Frameworks;

public class DbConnectionFactory(ILogger<DbConnectionFactory> logger, IConfiguration configuration)
{
    private readonly ILogger _logger = logger;
    private readonly IConfiguration _configuration = configuration;

    public IDbConnection CreateConnection(string key)
    {
        string? connectionString = _configuration.GetConnectionString(key);
        if (connectionString == null)
            throw new Exception($"Connection string '{key}' does not exist.");
        
        if (key.StartsWith("SQLite"))
            return new SQLiteConnection(connectionString);
        
        throw new Exception($"key {key} not supported");
    }
}