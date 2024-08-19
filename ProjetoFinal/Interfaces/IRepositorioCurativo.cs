using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioCurativo
    {
        Task<Curativo?> GetCurativoByCondicaoAsync(Func<Curativo, bool> condicao);
        Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Func<Curativo, bool> condicao);
        Task<bool> SaveCurativoAsync(Curativo curativo);
    }
}
