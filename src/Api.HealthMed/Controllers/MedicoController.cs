using Api.HealthMed.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api.HealthMed.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly ILogger<MedicoController> _logger;

        public MedicoController(ILogger<MedicoController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public bool Cadastrar(Medico novoMedico)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public bool Login(Medico medico)
        {
            throw new NotImplementedException();
        }


        [HttpPost]
        public bool CadastrarHorario(HorarioDisponivel horarioDisponivel)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public bool EditarHorario(HorarioDisponivel horarioDisponivel)
        {
            throw new NotImplementedException();
        }
    }
}
