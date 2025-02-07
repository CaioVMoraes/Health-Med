using System.Data;

namespace Api.HealthMed.Infrastructure.Interfaces.Connection
{
    public interface IDatabaseConnection
    {
        IDbConnection AbrirConexao();
    }
}
