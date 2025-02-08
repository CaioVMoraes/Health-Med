using Api.HealthMed.Application.Interfaces.Services;
using Api.HealthMed.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
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
        public ActionResult<Retorno> Cadastrar([FromBody] Medico novoMedico)
        {
            try
            {
                _medicoService.CadastrarMedico(novoMedico);
                return Created(string.Empty, new Retorno
                {
                    Sucesso = true,
                    Mensagem = "Médico cadastrado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao cadastrar médico: {ex.Message}"
                });
            }
        }

        [HttpPost("Login")]
        public ActionResult<Retorno> Login(string crm, string senha)
        {
            try
            {
                // Validação das entradas
                if (string.IsNullOrEmpty(crm) && string.IsNullOrEmpty(senha))
                {
                    return BadRequest(new Retorno
                    {
                        Sucesso = false,
                        Mensagem = "Informe o CRM e a senha para realizar o login!"
                    });
                }
                if (string.IsNullOrEmpty(crm))
                {
                    return BadRequest(new Retorno
                    {
                        Sucesso = false,
                        Mensagem = "Informe o seu CRM para realizar o login!"
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
                if (!_medicoService.Login(crm, senha))
                {
                    return Unauthorized(new Retorno
                    {
                        Sucesso = false,
                        Mensagem = "CRM ou senha inválidos."
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

        [HttpPost("CadastrarHorario")]
        public ActionResult<Retorno> CadastrarHorario(ConsultaDisponivel consultaDisponivel)
        {
            try
            {
                _medicoService.CadastrarHorario(consultaDisponivel);

                return Created(string.Empty, new Retorno
                {
                    Sucesso = true,
                    Mensagem = "Horário cadastrado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao cadastrar horário: {ex.Message}"
                });
            }
        }

        [HttpPut("EditarHorario")]
        public ActionResult<Retorno> EditarHorario(ConsultaDisponivel consultaDisponivel)
        {
            try
            {
                _medicoService.EditarHorario(consultaDisponivel);

                return Ok(new Retorno
                {
                    Sucesso = true,
                    Mensagem = "Horário atualizado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao atualizar o horário: {ex.Message}"
                });
            }
        }
    }
}
