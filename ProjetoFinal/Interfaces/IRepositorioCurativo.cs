using ProjetoFinal.Models;
using System.Linq.Expressions;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioCurativo
    {
        Task<Curativo?> GetCurativoByCondicaoAsync(Expression<Func<Curativo, bool>> condicao);
        Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Expression<Func<Curativo, bool>> condicao);
        Task<bool> SaveCurativoAsync(Curativo curativo);
    }
}
