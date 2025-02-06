using Api.HealthMed.Helpers;
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
            ArgumentNullException.ThrowIfNull(novoPaciente);
            ArgumentNullException.ThrowIfNullOrEmpty(novoPaciente.Nome);
            ArgumentNullException.ThrowIfNullOrEmpty(novoPaciente.CPF);
            ArgumentNullException.ThrowIfNullOrEmpty(novoPaciente.Email);
            ArgumentNullException.ThrowIfNullOrEmpty(novoPaciente.Senha);

            return _pacienteService.Cadastrar(novoPaciente);
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
