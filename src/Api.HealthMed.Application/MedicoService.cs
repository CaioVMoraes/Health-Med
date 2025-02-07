using Api.HealthMed.Application.Interfaces.Services;
using Api.HealthMed.Domain;
using Api.HealthMed.Helpers;
using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using static Api.HealthMed.Helpers.Exceptions.CustomExceptions;

namespace Api.HealthMed.Application
{
    public class MedicoService(IMedicoRepository medicoRepository) : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository = medicoRepository;

        public async Task<int> CadastrarMedico(Medico novoMedico)
        {
            Validations.ValidarMedico(novoMedico);

            if (!Validations.ValidarCPF(novoMedico.CPF))
                throw new CPFInvalidoException();

            if (!Validations.ValidarEmail(novoMedico.Email))
                throw new EmailInvalidoException();

            novoMedico.Senha = StringHelper.Criptografar(novoMedico.Senha);

            return await _medicoRepository.CadastrarMedico(novoMedico);
        }

        public bool Login(Medico medico)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(medico.Senha);
            medico.Senha = StringHelper.Criptografar(medico.Senha);

            return _medicoRepository.Login(medico);
        }

        public bool CadastrarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return _medicoRepository.CadastrarHorario(consultaDisponivel);
        }

        public bool EditarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return _medicoRepository.EditarHorario(consultaDisponivel);
        }
    }
}
