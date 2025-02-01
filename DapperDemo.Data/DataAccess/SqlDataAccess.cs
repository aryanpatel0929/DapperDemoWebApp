using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using Dapper;
namespace DapperDemo.Data.DataAccess
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storeProcedure, U parameters)
        {
            string? connectionString = "Server=localhost,1433; Database=msdb; User=sa; Password=yourStrong(!)Password;TrustServerCertificate=true";
            using IDbConnection connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<T>(storeProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string? connectionString = "Server=localhost,1433; Database=msdb; User=sa; Password=yourStrong(!)Password;TrustServerCertificate=true";
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(sql, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}