using Api.HealthMed.Domain;
using Api.HealthMed.Infrastructure.Interfaces.Connection;
using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using Dapper;
using System.Data;
using System.Data.Common;

namespace Api.HealthMed.Infrastructure.Repositories
{
    public class PacienteRepository(IDatabaseConnection dbConnection) : IPacienteRepository
    {
        private readonly IDatabaseConnection _dbConnection = dbConnection;

        public bool Cadastrar(Paciente novoPaciente)
        {
            return false;
        }

        public bool Login(string emailCpf, string senha)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"SELECT COUNT(*) FROM Paciente WITH (NOLOCK) WHERE Senha = @Senha AND (Email = @EmailCPF OR CPF = @EmailCPF)";

            return conn.QueryFirstOrDefault<int>(query, new { @EmailCPF = emailCpf, @Senha = senha }) > 0;
        }

        public IEnumerable<Medico> ListarMedicos()
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"SELECT
                                *
                             FROM
                                Medico WITH (NOLOCK)
                             WHERE
                                EXISTS (
                                    SELECT COUNT(*) FROM ConsultaDisponivel WITH (NOLOCK)
                                    WHERE ConsultaDisponivel.IdMedico = Medico.Id AND Disponivel = 1
                                )
                            ";

            return conn.Query<Medico>(query);
        }

        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            return false;
        }
    }
}
