using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Curativo;

namespace ProjetoFinal.Interfaces
{
    public interface ICurativoService
    {
        Task <int>RegistrarCurativoAsync(RegisterCurativoRequest curativo, int idProfissional);
        Task<int> UpdateCurativoAsync(UpdateCurativoRequest curativoRequest, int idProfissional);
        Task<CurativoDto?> GetCurativoById(int id);
        Task<PaginacaoResult<CurativoResumoResult>> GetPagesCurativosParametroAsync(string parametro, int pageNumber, int pageSize);
        Task<PaginacaoResult<CurativoResumoResult>> GetPagedCurativosByProfissionalAsync(int profissionalId, int pageNumber, int pageSize);
        Task<Curativo?> GetCurativoAsync(int parametro);
        Task<IEnumerable<CurativoResumoResult>> GetUltimosCurativos(int idProfissional);
        Task<PaginacaoResult<CurativoResumoResult>> GetPagesCurativosByProfissionalAsync(int profissionalId, int pageNumber, int pageSize);
    }
}
