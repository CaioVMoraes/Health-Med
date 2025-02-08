using Api.HealthMed.Domain;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        bool Cadastrar(Medico novoMedico);
        string GetSenha(string crm);
        bool CadastrarConsulta(ConsultaDisponivel consultaDisponivel);
        bool EditarConsulta(ConsultaDisponivel consultaDisponivel);
    }
}
