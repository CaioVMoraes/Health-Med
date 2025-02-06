using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using Api.HealthMed.Model;
using Api.HealthMed.Services.Interfaces.Services;

namespace Api.HealthMed.Services
{
    public class PacienteService(IPacienteRepository pacienteRepository) : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository = pacienteRepository;

        public bool Cadastrar(Paciente novoPaciente)
        {
            return _pacienteRepository.Cadastrar(novoPaciente);
        }

        public bool Login(Paciente paciente)
        {
            return _pacienteRepository.Login(paciente);
        }

        public IEnumerable<Medico> ListarMedicos()
        {
            return _pacienteRepository.ListarMedicos();
        }

        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            return _pacienteRepository.CadastrarAgendamento(agendamento);
        }
    }
}
