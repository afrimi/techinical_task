using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace TechnicalTask.DataAccess;

public class SqlDataAccess : ISqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    )
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(sql, param);
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    )
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param);
    }

    public async Task<T> QuerySingleAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    )
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QuerySingleAsync<T>(sql, param);
    }
    
    public async Task<T> QuerySingleOrDefaultAsync<T>(
        string sql,
        object? param = null,
        string connectionId = "Default"
    )
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QuerySingleOrDefaultAsync<T>(sql, param);
    }

    public async Task<int> ExecuteAsync(
        string sql,
        object? param = null,
        string connectionId = "Default"
    )
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.ExecuteAsync(sql, param);
    }
}