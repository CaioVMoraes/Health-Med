using Api.HealthMed.Domain.Settings;
using Api.HealthMed.Infrastructure.Interfaces.Connection;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace Api.HealthMed.Infrastructure.Connection
{
    public class DatabaseConnection(IOptions<DbSettings> dbSettings) : IDatabaseConnection
    {
        private readonly DbSettings _dbSettings = dbSettings.Value;

        public IDbConnection AbrirConexao()
        {
            SqlConnection connection = new SqlConnection(_dbSettings.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
