using Api.HealthMed.Infrastructure.Interfaces.Connection;
using Microsoft.Extensions.Options;
using Api.HealthMed.Model.Settings;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

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
