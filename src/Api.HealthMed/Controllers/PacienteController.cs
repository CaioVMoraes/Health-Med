using Api.HealthMed.Model;
using Api.HealthMed.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.HealthMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly ILogger<PacienteController> _logger;
        private readonly IPacienteService _pacienteService;

        public PacienteController(ILogger<PacienteController> logger, IPacienteService pacienteService)
        {
            _logger = logger;
            _pacienteService = pacienteService;
        }

        [HttpPost("Cadastrar")]
        public bool Cadastrar(Paciente novoPaciente)
        {
            return _pacienteService.Cadastrar(novoPaciente);
        }

        [HttpPost("Login")]
        public bool Login(Paciente paciente)
        {
            return _pacienteService.Login(paciente);
        }

        [HttpGet("ListarMedicos")]
        public IEnumerable<Medico> ListarMedicos()
        {
            return _pacienteService.ListarMedicos();
        }

        [HttpPost("CadastrarAgendamento")]
        public bool CadastrarAgendamento(Agendamento agendamento)
        {
            return _pacienteService.CadastrarAgendamento(agendamento);
        }
    }
}
