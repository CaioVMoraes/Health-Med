using Api.HealthMed.Model;
using Api.HealthMed.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using static Api.HealthMed.Helpers.Exceptions.CustomExceptions;

namespace Api.HealthMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly ILogger<MedicoController> _logger;
        private readonly IMedicoService _medicoService;

        public MedicoController(ILogger<MedicoController> logger, IMedicoService medicoService)
        {
            _logger = logger;
            _medicoService = medicoService;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            _medicoService.Cadastrar(novoMedico);
            return Ok("Médico cadastrado com sucesso!");
        }



        [HttpPost("Login")]
        public bool Login(Medico medico)
        {
            ArgumentNullException.ThrowIfNullOrEmpty(medico.Senha);

            if (string.IsNullOrEmpty(medico.CPF) && string.IsNullOrEmpty(medico.Email) && string.IsNullOrEmpty(medico.CRM))
            {
                throw new ArgumentException("Informe o e-mail ou CPF ou CRM para realizar o login!");
            }

            return _medicoService.Login(medico);
        }

        [HttpPost("CadastrarHorario")]
        public bool CadastrarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return _medicoService.CadastrarHorario(consultaDisponivel);
        }

        [HttpPut("EditarHorario")]
        public bool EditarHorario(ConsultaDisponivel consultaDisponivel)
        {
            return _medicoService.EditarHorario(consultaDisponivel);
        }
    }
}
