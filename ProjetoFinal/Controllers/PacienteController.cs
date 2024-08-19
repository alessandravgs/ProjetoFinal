using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Controllers
{
    [ApiController]
    [Route("paciente")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacienteController(IPacienteService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterPacienteRequest paciente)
        {
            try
            {
                await _service.RegistrarPacienteAsync(paciente);
                return Ok();
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("buscar")]
        //[Authorize]
        public async Task<IActionResult> GetPaciente(string parametro)
        {
            if (string.IsNullOrEmpty(parametro))
            {
                return Unauthorized("Parâmetro inválido.");
            }

            var paciente = await _service.GetPacienteAsync(parametro);

            if (paciente == null)
            {
                return NotFound("Nenhum paciente encontrado com os dados solicitados.");
            }

            return Ok(paciente);
        }
    }
}
