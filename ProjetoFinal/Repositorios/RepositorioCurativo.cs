using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioCurativo: IRepositorioCurativo
    {
        private readonly ApiDbContext _context;
        public RepositorioCurativo(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Curativo?> GetCurativoByCondicaoAsync(Func<Curativo, bool> condicao)
        {
            return await _context.Curativos.FirstOrDefaultAsync(p => condicao(p));
        }

        public async Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Func<Curativo, bool> condicao)
        {
            return await _context.Curativos.Where(p => condicao(p)).ToListAsync();
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
