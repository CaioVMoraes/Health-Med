using Api.HealthMed.Application.Interfaces.Services;
using Api.HealthMed.Domain;
using Api.HealthMed.Helpers;
using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using Api.HealthMed.Infrastructure.Repositories;
using static Api.HealthMed.Helpers.Exceptions.CustomExceptions;

namespace Api.HealthMed.Application
{
    public class PacienteService(IPacienteRepository pacienteRepository) : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository = pacienteRepository;

        public bool Cadastrar(Paciente novoPaciente)
        {
            Validations.ValidarPaciente(novoPaciente);

            if (!Validations.ValidarCPF(novoPaciente.CPF!))
                throw new CPFInvalidoException();

            if (!Validations.ValidarEmail(novoPaciente.Email!))
                throw new EmailInvalidoException();

            novoPaciente.Senha = StringHelper.Criptografar(novoPaciente.Senha!);

            return _pacienteRepository.Cadastrar(novoPaciente);
        }

        public bool Login(string emailCpf, string senha)
        {
            string senhaHasheada = _pacienteRepository.GetSenha(emailCpf);

            if (StringHelper.VerificarSenha(senha, senhaHasheada))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<Medico> ListarMedicos()
        {
            return _pacienteRepository.ListarMedicos();
        }

        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            Validations.ValidarAgendamento(agendamento);

            return _pacienteRepository.CadastrarAgendamento(agendamento);
        }

        public bool CancelaAgendamento(Agendamento agendamento)
        {
            Validations.ValidarAgendamento(agendamento);

            return _pacienteRepository.CancelaAgendamento(agendamento);
        }
    }
}
