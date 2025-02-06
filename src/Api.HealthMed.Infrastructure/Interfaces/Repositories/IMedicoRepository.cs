using Api.HealthMed.Model;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        bool Cadastrar(Medico novoMedico);
        bool Login(Medico medico);
        bool CadastrarHorario(ConsultaDisponivel consultaDisponivel);
        bool EditarHorario(ConsultaDisponivel consultaDisponivel);
    }
}
