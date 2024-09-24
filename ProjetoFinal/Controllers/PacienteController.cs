using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Requests;
using System.Security.Claims;

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
        //[Authorize]
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

        [HttpGet("paginado")]
        //[Authorize]
        public async Task<IActionResult> GetPagedPacientesByProfissional([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
                {
                    return Unauthorized("ID do profissional não encontrado no token.");
                }

                var pacientes = await _service.GetPagedPacientesByProfissionalAsync(profissionalId, pageNumber, pageSize);
                return Ok(pacientes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }           
        }

        [HttpGet("alergias")]
        //[Authorize]
        public async Task<IActionResult> GetAlergias()
        {
            var paciente = await _service.GetAlergiasAsync();
            return Ok(paciente);
        }

        [HttpGet("comorbidades")]
        //[Authorize]
        public async Task<IActionResult> GetComorbidades()
        {
            var paciente = await _service.GetComorbidadesAsync();
            return Ok(paciente);
        }
    }
}
