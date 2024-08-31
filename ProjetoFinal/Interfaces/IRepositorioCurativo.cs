using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using System.Linq.Expressions;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioCurativo
    {
        Task<Curativo?> GetCurativoByCondicaoAsync(Expression<Func<Curativo, bool>> condicao);
        Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Expression<Func<Curativo, bool>> condicao);
        Task<bool> SaveCurativoAsync(Curativo curativo);
        Task<IEnumerable<CurativoResumoResult>> GetUltimosCurativos(int idProfissional);
        Task<PaginacaoResult<CurativoResumoResult>> GetCurativosByProfissionalAsync(int idProfissional, int pageNumber, int pageSize);
        Task<bool> SaveLesaoAsync(Lesao lesao);
    }
}
