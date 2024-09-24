using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using System.Linq;
using System.Linq.Expressions;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly ApiDbContext _context;
        public RepositorioPaciente(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente?> GetPacienteByCondicaoAsync(Expression<Func<Paciente, bool>> condicao)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(condicao);
        }

        public async Task<Paciente> SavePacienteAsync(Paciente paciente)
        {
            try
            {
                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();
                return paciente;
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("Erro ao salvar Paciente.");
            }
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPacientesByProfissional(int idProfissional, int pageNumber, int pageSize)
        {
            //var query = _context.Curativos.Where(x => x.Profissional.Id == idProfissional).Select(x => x.Lesao.Paciente).Distinct();
            var query = _context.Curativos.Select(x => x.Lesao.Paciente).Distinct();
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new PacienteResumoResult
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    Sexo = x.Sexo,
                    Cpf = x.Cpf,
                })
                .ToListAsync();

            return new PaginacaoResult<PacienteResumoResult>()
            {
                TotalItems = totalItems,
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<AlergiaComorbidadeResumoResult>> GetAlergiasAsync()
        {
            return await _context.Alergias
                .Select(x => new AlergiaComorbidadeResumoResult()
                {
                    Id = x.Id,
                    Nome = x.Nome
                })
                .ToListAsync();
        }

        public async Task<List<Alergia>> GetAlergiasByListIdAsync(List<int> alergiasId)
        {
            return await _context.Alergias
                .Where(a => alergiasId.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<List<AlergiaComorbidadeResumoResult>> GetComorbidadesAsync()
        {
            return await _context.Comorbidades
                .Select(x => new AlergiaComorbidadeResumoResult()
                {
                    Id = x.Id,
                    Nome = x.Nome
                }).ToListAsync();
        }

        public async Task<List<Comorbidade>> GetComorbidadesByListIdAsync(List<int> comorbidadesId)
        {
            return await _context.Comorbidades
                .Where(a => comorbidadesId.Contains(a.Id))
                .ToListAsync();
        }

    }
}
