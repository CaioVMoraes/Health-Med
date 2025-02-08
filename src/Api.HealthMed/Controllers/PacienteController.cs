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
        public bool Login(string emailCpf, string senha)
        {
            if (string.IsNullOrEmpty(emailCpf) && string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("Informe o seu e-mail ou CPF e a senha para realizar o login!");
            }
            if (string.IsNullOrEmpty(emailCpf))
            {
                throw new ArgumentException("Informe o seu e-mail ou CPF para realizar o login!");
            }
            if (string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("Informe sua senha para realizar o login!");
            }
            
            return _pacienteService.Login(emailCpf, senha);
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
