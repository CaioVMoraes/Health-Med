using Api.HealthMed.Domain;

namespace Api.HealthMed.Application.Interfaces.Services
{
    public interface IMedicoService
    {
        bool Cadastrar(Medico novoMedico);
        bool Login(string crm, string senha);
        bool CadastrarConsulta(ConsultaDisponivel consultaDisponivel);
        bool EditarConsulta(ConsultaDisponivel consultaDisponivel);
    }
}
