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

        public bool Cadastrar(Medico novoMedico)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"
                            INSERT INTO Medico
                                    (Nome,
                                     CPF,
                                     CRM,
                                     Email,
                                     Senha,
                                     Especializacao,
                                     DataCadastro,
                                     Ativo) 
                                VALUES
                                    (@Nome,
                                     @CPF,
                                     @CRM,
                                     @Email,
                                     @Senha,
                                     @Especializacao,
                                     GETDATE(),
                                     1)"
            ;

            return conn.Execute(query, novoMedico) > 0;
        }

        public string GetSenha(string crm)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"SELECT TOP 1 Senha FROM Medico WITH (NOLOCK) WHERE CRM = @CRM";

            return conn.QueryFirstOrDefault<string>(query, new { @CRM = crm }) ?? throw new UnauthorizedAccessException("Não foi possível localizar o usuário com esse CRM.");
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
