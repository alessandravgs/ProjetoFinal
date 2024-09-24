using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface ICoberturaService
    {
        Task<CoberturaResumoResult> SaveCoberturaAsync(RegisterCobertura registerCobertura);
        Task<PaginacaoResult<CoberturaResumoResult>> GetPagesCoberturasAsync(int pageNumber, int pageSize);
        Task<PaginacaoResult<CoberturaResumoResult>> GetPagesCoberturasParametroAsync(string parametro, int pageNumber, int pageSize);
        Task<CoberturaResumoResult> UpdateCoberturaAsync(CoberturaUpdateRequest coberturaAtualizar);
    }
}
