using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using System.Linq.Expressions;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioCurativo: IRepositorioCurativo
    {
        private readonly ApiDbContext _context;
        public RepositorioCurativo(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Curativo?> GetCurativoByCondicaoAsync(Expression<Func<Curativo, bool>> condicao)
        {
            return await _context.Curativos.FirstOrDefaultAsync(condicao);
        }

        public async Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Expression<Func<Curativo, bool>> condicao)
        {
            return await _context.Curativos.Where(condicao).ToListAsync();
        }

        public async Task<bool> SaveCurativoAsync(Curativo curativo)
        {
            try
            {
                _context.Curativos.Add(curativo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CurativoResumoResult>> GetUltimosCurativos(int idProfissional)
        {
            return await _context.Curativos.Where(x => x.Profissional.Id == idProfissional)
                .OrderByDescending(x => x.Data)
                .Take(5)
                .Select(x => new CurativoResumoResult
                {
                    Id = x.Id,
                    Lesao = x.Lesao.Detalhes,
                    Paciente = x.Lesao.Paciente.Nome,
                    Data = x.Data
                })
                .ToListAsync();
        }

        public async Task<PaginacaoResult<CurativoResumoResult>> GetCurativosByProfissionalAsync(int idProfissional, int pageNumber, int pageSize)
        {
            var query = _context.Curativos.Where(x => x.Profissional.Id == idProfissional).OrderByDescending(x => x.Data);
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CurativoResumoResult
                {
                    Id = x.Id,
                    Lesao = x.Lesao.Detalhes,
                    Paciente = x.Lesao.Paciente.Nome,
                    Data = x.Data
                })
                .ToListAsync();

            return new PaginacaoResult<CurativoResumoResult>()
            {
                TotalItems = totalItems,
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<bool> SaveLesaoAsync(Lesao lesao)
        {
            try
            {
                _context.Lesoes.Add(lesao);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
