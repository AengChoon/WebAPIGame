using System.Data;

namespace Server.Frameworks;

public class Repository : IDisposable
{
    private IDbConnection? _connection;
    private IDbTransaction? _transaction;

    public Repository(DbConnectionFactory factory, string connectionString)
    {
        _connection = factory.CreateConnection(connectionString);
        EnsureOpen();
        _transaction = _connection.BeginTransaction();
    }

    protected IDbConnection EnsureOpen()
    {
        if (_connection!.State != ConnectionState.Open)
            _connection.Open();
        
        return _connection;
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing == false)
            return;

        if (_connection != null)
        {
            _connection.Dispose();
            _connection = null;
        }

        if (_transaction != null)
        {
            _transaction.Dispose();
            _transaction = null;
        }
    }
}