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

        public async Task<int> CadastrarMedico(Medico novoMedico)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"
                            INSERT INTO Medico (Nome, CPF, CRM, Email, Senha, Especializacao, DataCadastro, Ativo) 
                            VALUES (@Nome, @CPF, @CRM, @Email, @Senha, @Especializacao, GETDATE(), 1)"
            ;

            return await conn.QuerySingleAsync<int>(query);
        }

        public bool Login(Medico medico)
        {
            return false;
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
