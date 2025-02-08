using Api.HealthMed.Domain;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        Task<bool> CadastrarMedico(Medico novoMedico);
        bool Login(string crm, string senha);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
