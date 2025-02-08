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
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"
                            INSERT INTO Paciente
                                   (Nome
                                   ,CPF
                                   ,Email
                                   ,Senha
                                   ,DataCadastro
                                   ,Ativo)
                             VALUES
                                   (@Nome
                                   ,@CPF
                                   ,@Email
                                   ,@Senha
                                   ,GETDATE()
                                   ,1)"
            ;

            return conn.Execute(query, novoPaciente) > 0;
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
                                Id,
                                Nome,
                                CRM,
                                Email,
                                Especializacao
                             FROM
                                Medico WITH (NOLOCK)
                             WHERE
                                EXISTS (
                                    SELECT * FROM ConsultaDisponivel WITH (NOLOCK)
                                    WHERE ConsultaDisponivel.IdMedico = Medico.Id AND Disponivel = 1 AND ConsultaDisponivel.DataHora >= DATEADD(day, 1, GETDATE())
                                )
                                AND Ativo = 1
                             ORDER BY
                                Nome
                            ";

            return conn.Query<Medico>(query);
        }

        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"
                            INSERT INTO [dbo].[Agendamento]
                                   (IdPaciente
                                   ,IdMedico
                                   ,IdConsulta
                                   ,MedicoAceitou
                                   ,MedicoRecusou
                                   ,PacienteCancelou
                                   ,JustificativaCancelamento
                                   ,Ativo
                                   ,DataCadastro)
                             VALUES
                                   (@IdPaciente
                                   ,@IdMedico
                                   ,@IdConsulta
                                   ,@MedicoAceitou
                                   ,@MedicoRecusou
                                   ,@PacienteCancelou
                                   ,@JustificativaCancelamento
                                   ,1
                                   ,GETDATE())"
            ;

            return conn.Execute(query, agendamento) > 0;
        }

        public bool CancelaAgendamento(Agendamento agendamento)
        {
            using IDbConnection conn = _dbConnection.AbrirConexao();

            string query = @"
                            UPDATE Agendamento
                               SET PacienteCancelou = @PacienteCancelou
                                  ,JustificativaCancelamento = @JustificativaCancelamento
                                  ,DataAtualizacao = GETDATE()
                             WHERE Id = @Id"
            ;

            return conn.Execute(query, agendamento) > 0;
        }
    }
}
