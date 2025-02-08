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

        public bool Cadastrar(Medico novoMedico)
        {
            Validations.ValidarMedico(novoMedico);

            if (!Validations.ValidarCPF(novoMedico.CPF!))
                throw new CPFInvalidoException();

            if (!Validations.ValidarEmail(novoMedico.Email!))
                throw new EmailInvalidoException();

            novoMedico.Senha = StringHelper.Criptografar(novoMedico.Senha!);

            return _medicoRepository.Cadastrar(novoMedico);
        }

        public bool Login(string crm, string senha)
        {
            string senhaHasheada = _medicoRepository.GetSenha(crm);

            if (StringHelper.VerificarSenha(senha, senhaHasheada))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CadastrarConsulta(ConsultaDisponivel consultaDisponivel)
        {
            Validations.ValidarConsulta(consultaDisponivel);

            return _medicoRepository.CadastrarConsulta(consultaDisponivel);
        }

        public bool EditarConsulta(ConsultaDisponivel consultaDisponivel)
        {
            Validations.ValidarConsulta(consultaDisponivel);

            return _medicoRepository.EditarConsulta(consultaDisponivel);
        }

        public bool AceitaRecusaAgendamento(Agendamento agendamento)
        {
            Validations.ValidarAgendamento(agendamento);

            return _medicoRepository.AceitaRecusaAgendamento(agendamento);
        }
    }
}
