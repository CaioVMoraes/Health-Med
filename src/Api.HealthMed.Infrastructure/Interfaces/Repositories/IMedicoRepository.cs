using Api.HealthMed.Domain;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        Task<int> CadastrarMedico(Medico novoMedico);
        bool Login(Medico medico);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
