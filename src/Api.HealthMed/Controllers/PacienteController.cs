using Api.HealthMed.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.HealthMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ILogger<PacienteController> _logger;

        public PacienteController(ILogger<PacienteController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool Cadastrar(Paciente novoPaciente)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public bool Login(Paciente paciente)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<Medico> ListarMedicos()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            throw new NotImplementedException();
        }
    }
}
