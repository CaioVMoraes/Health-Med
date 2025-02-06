using Api.HealthMed.Model;

namespace Api.HealthMed.Infrastructure.Interfaces.Repositories
{
    public interface IMedicoRepository
    {
        bool Cadastrar(Medico novoMedico);
        bool Login(Medico medico);
        bool CadastrarHorario(HorarioDisponivel horarioDisponivel);
        bool EditarHorario(HorarioDisponivel horarioDisponivel);
    }
}
