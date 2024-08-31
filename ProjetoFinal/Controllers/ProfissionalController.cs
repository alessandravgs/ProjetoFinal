using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoFinal.Controllers
{
    [ApiController]
    [Route("profissional")]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalService _service;

        public ProfissionalController(IProfissionalService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Profissional profissional)
        {
            try
            {
                await _service.RegistrarProfissionalAsync(profissional);
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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                var token = await _service.LoginProfissionalAsync(login);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ping")]
        [Authorize]
        public IActionResult Ping()
        {
            return Ok(new { Message = "pong"});
        }

        [HttpGet("pacientes")]
        [Authorize]
        public async Task<IActionResult> GetPacientes()
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
            {
                return Unauthorized("ID do profissional não encontrado no token.");
            }

            var curativos = await _service.GetCurativosByProfissionalIdAsync(profissionalId);

            if (curativos == null || !curativos.Any())
            {
                return NotFound("Nenhum curativo encontrado para este profissional.");
            }

            return Ok(curativos);
        }

        [HttpGet("curativos")]
        [Authorize]
        public async Task<IActionResult> GetCurativos()
        {
            var userId = User.FindFirst(ClaimTypes.Name)?.Value;

            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
            {
                return Unauthorized("ID do profissional não encontrado no token.");
            }

            var curativos = await _service.GetCurativosByProfissionalIdAsync(profissionalId);

            if (curativos == null || !curativos.Any())
            {
                return NotFound("Nenhum paciente encontrado para este profissional.");
            }

            return Ok(curativos);
        }
    }

    public class LoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
