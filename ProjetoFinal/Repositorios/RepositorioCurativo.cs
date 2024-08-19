using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
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
    }
}
