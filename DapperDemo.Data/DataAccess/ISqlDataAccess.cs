namespace DapperDemo.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters);
        Task SaveData<T>(string sql, T parameters);
    }
}