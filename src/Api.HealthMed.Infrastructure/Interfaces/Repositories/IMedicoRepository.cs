using Api.HealthMed.Domain;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        bool Cadastrar(Medico novoMedico);
        string GetSenha(string crm);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
