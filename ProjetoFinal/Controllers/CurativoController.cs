using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Service;
using System.Security.Claims;

namespace ProjetoFinal.Controllers
{
    [ApiController]
    [Route("curativo")]
    public class CurativoController : ControllerBase
    {
        private readonly ICurativoService _service;

        public CurativoController(ICurativoService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Curativo curativo)
        {
            try
            {
                await _service.RegistrarCurativoAsync(curativo);
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
        [Authorize]
        public async Task<IActionResult> GetCurativo(int parametro)
        {
            if (parametro == null || parametro < 0)
            {
                return Unauthorized("Parâmetro inválido.");
            }

            var curativo = await _service.GetCurativoAsync(parametro);

            if (curativo == null)
            {
                return NotFound("Nenhum curativo encontrado com os dados solicitados.");
            }

            return Ok(curativo);
        }

        [HttpGet("ultimos")]
        [Authorize]
        public async Task<IActionResult> GetUltimosCurativosByProfissional()
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
                {
                    return Unauthorized("ID do profissional não encontrado no token.");
                }

                var curativos = await _service.GetUltimosCurativos(profissionalId);

                return Ok(curativos);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("paginado")]
        [Authorize]
        public async Task<IActionResult> GetPagedPacientesByProfissional([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
                {
                    return Unauthorized("ID do profissional não encontrado no token.");
                }

                var pagedResult = await _service.GetPagesCurativosByProfissionalAsync(profissionalId, pageNumber, pageSize);
                
                return Ok(pagedResult);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }           
        }

        [HttpPost("register/lesao")]
        [Authorize]
        public async Task<IActionResult> Register([FromBody] RegisterLesaoRequest lesao)
        {
            try
            {
                await _service.RegistrarLesaoAsync(lesao);
                return Ok();
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
    }
}
