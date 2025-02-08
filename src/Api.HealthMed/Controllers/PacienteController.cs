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
        public ActionResult<Retorno> Login(string emailCpf, string senha)
        {
            try
            {
                // Validação das entradas
                if (string.IsNullOrEmpty(emailCpf) && string.IsNullOrEmpty(senha))
                {
                    return BadRequest(new Retorno
                    {
                        Sucesso = false,
                        Mensagem = "Informe o seu e-mail ou CPF e a senha para realizar o login!"
                    });
                }
                if (string.IsNullOrEmpty(emailCpf))
                {
                    return BadRequest(new Retorno
                    {
                        Sucesso = false,
                        Mensagem = "Informe o seu e-mail ou CPF para realizar o login!"
                    });
                }
                if (string.IsNullOrEmpty(senha))
                {
                    return BadRequest(new Retorno
                    {
                        Sucesso = false,
                        Mensagem = "Informe sua senha para realizar o login!"
                    });
                }

                // Tenta realizar o login
                var loginSucesso = _pacienteService.Login(emailCpf, senha);

                if (!loginSucesso)
                {
                    return Unauthorized(new Retorno
                    {
                        Sucesso = false,
                        Mensagem = "E-mail/CPF ou senha inválidos."
                    });
                }

                return Ok(new Retorno
                {
                    Sucesso = true,
                    Mensagem = "Login realizado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao efetuar o login: {ex.Message}"
                });
            }
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
