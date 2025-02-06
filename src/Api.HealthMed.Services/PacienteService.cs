using Api.HealthMed.Helpers;
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
            ArgumentNullException.ThrowIfNull(novoPaciente);
            ArgumentNullException.ThrowIfNullOrEmpty(novoPaciente.CPF);

            if (StringHelper.ValidarCPF(novoPaciente.CPF))
                throw new ArgumentException("CPF inválido");

            ArgumentNullException.ThrowIfNullOrEmpty(novoPaciente.Senha);
            novoPaciente.Senha = StringHelper.Criptografar(novoPaciente.Senha);

            return _pacienteRepository.Cadastrar(novoPaciente);
        }

        public bool Login(Paciente paciente)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(paciente.Senha);
            paciente.Senha = StringHelper.Criptografar(paciente.Senha);

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
