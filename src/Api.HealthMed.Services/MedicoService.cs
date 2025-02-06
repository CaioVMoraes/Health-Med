using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using Api.HealthMed.Model;
using Api.HealthMed.Services.Interfaces.Services;

namespace Api.HealthMed.Services
{
    public class MedicoService(IMedicoRepository medicoRepository) : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository = medicoRepository;

        public bool Cadastrar(Medico novoMedico)
        {
            return _medicoRepository.Cadastrar(novoMedico);
        }

        public bool Login(Medico medico)
        {
            return _medicoRepository.Login(medico);
        }

        public bool CadastrarHorario(HorarioDisponivel horarioDisponivel)
        {
            return _medicoRepository.CadastrarHorario(horarioDisponivel);
        }

        public bool EditarHorario(HorarioDisponivel horarioDisponivel)
        {
            return _medicoRepository.EditarHorario(horarioDisponivel);
        }
    }
}
