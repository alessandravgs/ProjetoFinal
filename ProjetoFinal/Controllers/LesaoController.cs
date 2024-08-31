using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Requests;

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
