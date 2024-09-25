using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Requests;
using System.Security.Claims;

namespace ProjetoFinal.Controllers
{
    [ApiController]
    [Route("cobertura")]
    public class CoberturaController : ControllerBase
    {
        private readonly ICoberturaService _service;

        public CoberturaController(ICoberturaService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCobertura cobertura)
        {
            try
            {
                var coberturaSalva = await _service.SaveCoberturaAsync(cobertura);
                return Ok(coberturaSalva);
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
        public async Task<IActionResult> Update([FromBody] CoberturaUpdateRequest cobertura)
        {
            try
            {
                var coberturaSalva = await _service.UpdateCoberturaAsync(cobertura);
                return Ok(coberturaSalva);
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

        [HttpGet("paginado")]
        public async Task<IActionResult> GetCoberturasPaginado([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var coberturas = await _service.GetPagesCoberturasAsync(pageNumber, pageSize);
                return Ok(coberturas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetCoberturasSearch([FromQuery] string parametro, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var coberturas = await _service.GetPagesCoberturasParametroAsync(parametro, pageNumber, pageSize);
                return Ok(coberturas);
            }
            catch(ArgumentNullException ex)
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
