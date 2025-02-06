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

        public bool CadastrarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return false;
        }

        public bool EditarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return false;
        }
    }
}
