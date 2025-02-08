using Api.HealthMed.Domain;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        bool Cadastrar(Paciente novoPaciente);
        string GetSenha(string emailCpf);
        IEnumerable<Medico> ListarMedicos();
        bool CadastrarAgendamento(Agendamento agendamento);
    }
}
