using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;

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
        public async Task<IActionResult> GetCurativo(string parametro)
        {
            if (string.IsNullOrEmpty(parametro))
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
    }
}
