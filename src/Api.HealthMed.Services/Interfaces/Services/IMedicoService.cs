using Api.HealthMed.Model;

namespace Api.HealthMed.Services.Interfaces.Services
{
    public interface IMedicoService
    {
        bool Cadastrar(Medico novoMedico);
        bool Login(Medico medico);
        bool CadastrarHorario(HorarioDisponivel horarioDisponivel);
        bool EditarHorario(HorarioDisponivel horarioDisponivel);
    }
}
