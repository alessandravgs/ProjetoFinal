using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Requests.Lesao;
using System.Security.Claims;

namespace ProjetoFinal.Controllers
{
    [ApiController]
    [Route("lesao")]
    public class LesaoController : ControllerBase
    {
        private readonly ILesaoService _service;

        public LesaoController(ILesaoService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        [Authorize]
        public async Task<IActionResult> Register([FromBody] RegisterLesaoRequest lesao)
        {
            try
            {
                var lesaoSalva = await _service.RegistrarLesaoAsync(lesao);
                return Ok(lesaoSalva);
            }
            catch (BadHttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] LesaoUpdateRequest lesaoUpdate)
        {
            try
            {
                var lesaoAtualizado = await _service.UpdateLesaoAsync(lesaoUpdate);
                return Ok(lesaoAtualizado);
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

        [HttpGet("id")]
        [Authorize]
        public async Task<IActionResult> GetLesaoById(int parametro)
        {
            if (parametro == null || parametro == 0)
            {
                return Unauthorized("Parâmetro inválido.");
            }

            var paciente = await _service.GetLesaoByIdAsync(parametro);

            return Ok(paciente);
        }

        [HttpGet("paginado")]
        [Authorize]
        public async Task<IActionResult> GetPagedLesaoByProfissional([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
                {
                    return Unauthorized("ID do profissional não encontrado no token.");
                }

                var lesoes = await _service.GetPagedLesoesByProfissionalAsync(profissionalId, pageNumber, pageSize);
                return Ok(lesoes);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("search")]
        [Authorize]
        public async Task<IActionResult> GetLesoesSearch([FromQuery] string parametro, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var lesoes = await _service.GetPagesLesaoParametroAsync(parametro, pageNumber, pageSize);
                return Ok(lesoes);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paciente")]
        [Authorize]
        public async Task<IActionResult> GetLesoesByPaciente([FromQuery] int parametro, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var lesoes = await _service.GetPagesLesaoByPacienteAsync(parametro, pageNumber, pageSize);
                return Ok(lesoes);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
