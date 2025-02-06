using Api.HealthMed.Model;

namespace Api.HealthMed.Services.Interfaces.Services
{
    public interface IPacienteService
    {
        bool Cadastrar(Paciente novoPaciente);
        bool Login(Paciente paciente);
        IEnumerable<Medico> ListarMedicos();
        bool CadastrarAgendamento(Agendamento agendamento);
    }
}
