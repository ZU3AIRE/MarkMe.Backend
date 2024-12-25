using Dapper;
using MarkMe.Database.Interface;
using Microsoft.Data.SqlClient;
using System.Data;


namespace MarkMe.Database
{
    public class DapperDatabase(string connectionString) : IDatabase
    {
        private readonly string _connectionString = connectionString;

        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public async Task<T?> QuerySingleAsync<T>(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<T>(sql, parameters);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null)
        {
            var connection = CreateConnection();
            return await connection.QueryAsync<T>(sql, parameters);
        }

        public async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(sql, parameters);
        }
    }
}
