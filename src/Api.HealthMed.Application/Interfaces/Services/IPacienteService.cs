using Api.HealthMed.Domain;

namespace Api.HealthMed.Application.Interfaces.Services
{
    public interface IPacienteService
    {
        bool Cadastrar(Paciente novoPaciente);
        bool Login(Paciente paciente);
        IEnumerable<Medico> ListarMedicos();
        bool CadastrarAgendamento(Agendamento agendamento);
    }
}
