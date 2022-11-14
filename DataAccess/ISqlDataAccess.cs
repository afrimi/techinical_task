namespace TechnicalTask.DataAccess;

public interface ISqlDataAccess
{
    Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    );

    Task<T> QueryFirstOrDefaultAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    );
    
    Task<T> QuerySingleAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    );
    
    Task<T> QuerySingleOrDefaultAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    );

    Task<int> ExecuteAsync(
        string sql,
        object? param = null,
        string connectionId = "Default"
    );
}