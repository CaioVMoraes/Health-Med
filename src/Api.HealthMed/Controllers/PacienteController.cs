using Api.HealthMed.Application.Interfaces.Services;
using Api.HealthMed.Domain;
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
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            _pacienteService.Cadastrar(novoPaciente);
            return Ok("Médico cadastrado com sucesso!");
        }

        [HttpPost("Login")]
        public bool Login(Paciente paciente)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(paciente.Senha);

            if (string.IsNullOrEmpty(paciente.CPF) && string.IsNullOrEmpty(paciente.Email))
            {
                throw new ArgumentException("Informe o e-mail ou CPF para realizar o login!");
            }

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
