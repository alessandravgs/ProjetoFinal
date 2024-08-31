using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using System.Linq;
using System.Linq.Expressions;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioPaciente: IRepositorioPaciente
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

        public async Task<bool> SavePacienteAsync(Paciente paciente)
        {
            try
            {
                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPacientesByProfissional(int idProfissional, int pageNumber, int pageSize)
        {
            var query = _context.Curativos.Where(x => x.Profissional.Id == idProfissional).Select(x => x.Lesao.Paciente).Distinct();
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

    }
}
