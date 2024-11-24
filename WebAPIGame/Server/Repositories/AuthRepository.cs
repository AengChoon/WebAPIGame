using System.Data;
using Dapper;
using Microsoft.Extensions.Options;
using Server.Frameworks;
using Server.Models;

namespace Server.Repositories;

public class AuthRepository(DbConnectionFactory factory, IOptions<AppSettings.ConnectionKeys> connectionKeys)
    : Repository(factory, connectionKeys.Value.Auth)
{
    public void CreateAccount()
    {
        IDbConnection connection = EnsureOpen();
        connection.ExecuteScalar<long>("INSERT INTO Account DEFAULT VALUES");
    }

    public Account? GetAccount(long inId)
    {
        IDbConnection connection = EnsureOpen();
        return connection.QuerySingle<Account>("SELECT * FROM Account WHERE Id = @Id", new { Id = inId });
    }
}