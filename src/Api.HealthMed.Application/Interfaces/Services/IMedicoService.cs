using Api.HealthMed.Domain;

namespace Api.HealthMed.Application.Interfaces.Services
{
    public interface IMedicoService
    {
        Task<int> CadastrarMedico(Medico novoMedico);
        bool Login(Medico medico);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
