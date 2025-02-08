using Api.HealthMed.Domain;

namespace Api.HealthMed.Application.Interfaces.Services
{
    public interface IMedicoService
    {
        Task<bool> CadastrarMedico(Medico novoMedico);
        bool Login(string crm, string senha);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
