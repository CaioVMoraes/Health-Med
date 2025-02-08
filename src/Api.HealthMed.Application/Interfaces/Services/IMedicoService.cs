using Api.HealthMed.Domain;

namespace Api.HealthMed.Application.Interfaces.Services
{
    public interface IMedicoService
    {
        bool Cadastrar(Medico novoMedico);
        bool Login(string crm, string senha);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
