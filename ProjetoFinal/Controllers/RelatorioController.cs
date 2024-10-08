﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Interfaces;
using System.Security.Claims;

namespace ProjetoFinal.Controllers
{
    [ApiController]
    [Route("relatorio")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _service;

        public RelatorioController(IRelatorioService service)
        {
            _service = service;
        }

        [HttpGet("total/paciente")]
        [Authorize]
        public async Task<IActionResult> GetRelatorioCurativosTotaisPaciente(int idPaciente)
        {
            try
            {
                var retorno = await _service.RelatorioCurativosTotalPacienteAsync(idPaciente);
                
                return Ok(retorno);
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

        [HttpGet("periodo/paciente")]
        [Authorize]
        public async Task<IActionResult> GetRelatorioCurativosPeridoPaciente(int idPaciente, DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var retorno = await _service.RelatorioCurativosPacientePeriodoAsync(idPaciente, dataInicial, dataFinal);
                return Ok(retorno);
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

        [HttpGet("periodo/profissional")]
        [Authorize]
        public async Task<IActionResult> GetRelatorioCurativosPeridoProfissional(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.Name)?.Value;

                if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int profissionalId))
                {
                    return Unauthorized("ID do profissional não encontrado no token.");
                }

                var retorno = await _service.RelatorioCurativosByProfissionalPeriodoAsync(1, dataInicial, dataFinal);
                return Ok(retorno);
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

        [HttpGet("lesao")]
        [Authorize]
        public async Task<IActionResult> GetRelatorioCurativosPorLesao(int lesaoId)
        {
            try
            {
                var retorno = await _service.RelatorioCurativosByLesaoAsync(lesaoId);
                return Ok(retorno);
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
