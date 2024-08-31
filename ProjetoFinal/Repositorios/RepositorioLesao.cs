using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioLesao: IRepositorioLesao
    {
        private readonly ApiDbContext _context;
        public RepositorioLesao(ApiDbContext context)
        {
            _context = context;
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
