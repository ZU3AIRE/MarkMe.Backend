namespace MarkMe.Database.Interface
{
    public interface IDatabase
    {
        Task<T?> QuerySingleAsync<T>(string sql, object? parameters = null);
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? parameters = null);
        Task<int> ExecuteAsync(string sql, object? parameters = null);
    }
}
