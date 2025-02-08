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

        public string GetSenha(string emailCpf)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"SELECT TOP 1 Senha FROM Paciente WITH (NOLOCK) WHERE Email = @EmailCPF OR CPF = @EmailCPF";

            return conn.QueryFirstOrDefault<string>(query, new { @EmailCPF = emailCpf}) ?? throw new UnauthorizedAccessException("Não foi possível localizar esse usuário.");
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
