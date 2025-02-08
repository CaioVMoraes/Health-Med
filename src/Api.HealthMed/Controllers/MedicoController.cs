using Api.HealthMed.Application.Interfaces.Services;
using Api.HealthMed.Domain;
using Microsoft.AspNetCore.Mvc;

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
            _medicoService.CadastrarMedico(novoMedico);
            return Ok("Médico cadastrado com sucesso!");
        }

        [HttpPost("Login")]
        public bool Login(string crm, string senha)
        {
            if (string.IsNullOrEmpty(crm) && string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("Informe o CRM e a senha para realizar o login!");
            }
            if (string.IsNullOrEmpty(crm))
            {
                throw new ArgumentException("Informe o seu CRM para realizar o login!");
            }
            if (string.IsNullOrEmpty(senha))
            {
                throw new ArgumentException("Informe sua senha para realizar o login!");
            }

            return _medicoService.Login(crm, senha);
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
