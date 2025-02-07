using Api.HealthMed.Model;

namespace Api.HealthMed.Services.Interfaces.Services
{
    public interface IMedicoService
    {
        Task<int> CadastrarMedico(Medico novoMedico);
        bool Login(Medico medico);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
