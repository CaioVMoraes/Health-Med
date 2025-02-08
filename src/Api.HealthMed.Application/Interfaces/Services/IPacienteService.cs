using Api.HealthMed.Domain;

namespace Api.HealthMed.Application.Interfaces.Services
{
    public interface IPacienteService
    {
        bool Cadastrar(Paciente novoPaciente);
        bool Login(string emailCpf, string senha);
        IEnumerable<Medico> ListarMedicos();
        bool CadastrarAgendamento(Agendamento agendamento);
        bool CancelaAgendamento(Agendamento agendamento);
    }
}
