using Api.HealthMed.Model;
using Api.HealthMed.Services.Interfaces.Services;
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
        public bool Cadastrar(Medico novoMedico)
        {
            return _medicoService.Cadastrar(novoMedico);
        }

        [HttpPost("Login")]
        public bool Login(Medico medico)
        {
            return _medicoService.Login(medico);
        }

        [HttpPost("CadastrarHorario")]
        public bool CadastrarHorario(HorarioDisponivel horarioDisponivel)
        {
            return _medicoService.CadastrarHorario(horarioDisponivel);
        }

        [HttpPut("EditarHorario")]
        public bool EditarHorario(HorarioDisponivel horarioDisponivel)
        {
            return _medicoService.EditarHorario(horarioDisponivel);
        }
    }
}
