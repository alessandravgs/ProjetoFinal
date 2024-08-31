using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface ICurativoService
    {
        Task RegistrarCurativoAsync(Curativo curativo);
        Task<Curativo?> GetCurativoAsync(int parametro);
        Task<IEnumerable<CurativoResumoResult>> GetUltimosCurativos(int idProfissional);
        Task<PaginacaoResult<CurativoResumoResult>> GetPagesCurativosByProfissionalAsync(int profissionalId, int pageNumber, int pageSize);
    }
}
