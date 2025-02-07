using Api.HealthMed.Domain;
using Api.HealthMed.Infrastructure.Interfaces.Repositories;

namespace Api.HealthMed.Infrastructure.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        public bool Cadastrar(Paciente novoPaciente)
        {
            return false;
        }

        public bool Login(Paciente paciente)
        {
            return false;
        }

        public IEnumerable<Medico> ListarMedicos()
        {
            return Enumerable.Empty<Medico>();
        }

        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            return false;
        }
    }
}
