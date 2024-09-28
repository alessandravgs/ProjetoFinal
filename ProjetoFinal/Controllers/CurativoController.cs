using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Curativo;
using ProjetoFinal.Requests.Lesao;
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
        public async Task<IActionResult> Register([FromBody] RegisterCurativoRequest curativo)
        {
            try
            {
                var id = await _service.RegistrarCurativoAsync(curativo);
                return Ok(id);
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

        [HttpPost("update")]
        //[Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateCurativoRequest curativoUpdate)
        {
            try
            {
                var curativoAtualizado = await _service.UpdateCurativoAsync(curativoUpdate);
                return Ok(curativoAtualizado);
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
        //[Authorize]
        public async Task<IActionResult> GetCurativoById(int? parametro)
        {
            if (parametro == null || parametro.Value == 0)
            {
                return Unauthorized("Parâmetro inválido.");
            }

            var curativo = await _service.GetCurativoById(parametro.Value);

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
        //[Authorize]
        public async Task<IActionResult> GetPagedCurativoByProfissional([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                //var userId = User.FindFirst(ClaimTypes.Name)?.Value;

                //if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
                //{
                //    return Unauthorized("ID do profissional não encontrado no token.");
                //}

                var curativos = await _service.GetPagedCurativosByProfissionalAsync(0, pageNumber, pageSize);
                return Ok(curativos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCurativoSearch([FromQuery] string parametro, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var curativos = await _service.GetPagesCurativosParametroAsync(parametro, pageNumber, pageSize);
                return Ok(curativos);
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
