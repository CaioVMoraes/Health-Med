using Api.HealthMed.Domain;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        bool Cadastrar(Paciente novoPaciente);
        bool Login(Paciente paciente);
        IEnumerable<Medico> ListarMedicos();
        bool CadastrarAgendamento(Agendamento agendamento);
    }
}
