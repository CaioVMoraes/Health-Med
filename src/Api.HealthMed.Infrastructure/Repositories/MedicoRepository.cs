using Api.HealthMed.Domain;
using Api.HealthMed.Infrastructure.Interfaces.Connection;
using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using Dapper;
using System.Data;

namespace Api.HealthMed.Infrastructure.Repositories
{
    public class MedicoRepository(IDatabaseConnection dbConnection) : IMedicoRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public async Task<bool> CadastrarMedico(Medico novoMedico)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"
                            INSERT INTO Medico (Nome, CPF, CRM, Email, Senha, Especializacao, DataCadastro, Ativo) 
                            VALUES (@Nome, @CPF, @CRM, @Email, @Senha, @Especializacao, GETDATE(), 1)"
            ;

            return await conn.ExecuteAsync(query) > 0;
        }

        public bool Login(string crm, string senha)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"SELECT COUNT(*) FROM Medico WITH (NOLOCK) WHERE CRM = @CRM AND Senha = @Senha";

            return conn.QueryFirstOrDefault<int>(query, new { @CRM = crm, @Senha = senha }) > 0;
        }

        public bool CadastrarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return false;
        }

        public bool EditarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return false;
        }
    }
}
