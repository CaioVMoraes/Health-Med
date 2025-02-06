using Api.HealthMed.Infrastructure.Interfaces.Repositories;
using Api.HealthMed.Model;

namespace Api.HealthMed.Infrastructure.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public bool Cadastrar(Medico novoMedico)
        {
            return false;
        }

        public bool Login(Medico medico)
        {
            return false;
        }

        public bool CadastrarHorario(HorarioDisponivel horarioDisponivel)
        {
            return false;
        }

        public bool EditarHorario(HorarioDisponivel horarioDisponivel)
        {
            return false;
        }
    }
}
