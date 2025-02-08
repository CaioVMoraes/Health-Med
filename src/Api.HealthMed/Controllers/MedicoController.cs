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
                _medicoService.Cadastrar(novoMedico);
                return Created(string.Empty, new Retorno
                {
                    Sucesso = true,
                    Mensagem = "M�dico cadastrado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao cadastrar m�dico: {ex.Message}"
                });
            }
        }

        [HttpPost("Login")]
        public ActionResult<Retorno> Login(string crm, string senha)
        {
            try
            {
                // Valida��o das entradas
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
                        Mensagem = "CRM ou senha inv�lidos."
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

        [HttpPost("CadastrarConsulta")]
        public ActionResult<Retorno> CadastrarConsulta(ConsultaDisponivel consultaDisponivel)
        {
            try
            {
                _medicoService.CadastrarConsulta(consultaDisponivel);

                return Created(string.Empty, new Retorno
                {
                    Sucesso = true,
                    Mensagem = "Consulta cadastrado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao cadastrar consulta: {ex.Message}"
                });
            }
        }

        [HttpPut("EditarConsulta")]
        public ActionResult<Retorno> EditarConsulta(ConsultaDisponivel consultaDisponivel)
        {
            try
            {
                _medicoService.EditarConsulta(consultaDisponivel);

                return Ok(new Retorno
                {
                    Sucesso = true,
                    Mensagem = "Consulta atualizado com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao atualizar o consulta: {ex.Message}"
                });
            }
        }

        [HttpPut("AceitaRecusaAgendamento")]
        public ActionResult<Retorno> AceitaRecusaAgendamento(Agendamento agendamento)
        {
            try
            {
                _medicoService.AceitaRecusaAgendamento(agendamento);

                return Ok(new Retorno
                {
                    Sucesso = true,
                    Mensagem = "Consulta atualizada com sucesso."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Retorno
                {
                    Sucesso = false,
                    Mensagem = $"Erro ao atualizar a consulta: {ex.Message}"
                });
            }
        }
    }
}
