using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioCobertura
    {
        Task<CoberturaResumoResult> SaveCobertura(Cobertura cobertura);
        Task<PaginacaoResult<CoberturaResumoResult>> GetCoberturasAsync(int pageNumber, int pageSize);
        Task<PaginacaoResult<CoberturaResumoResult>> GetCoberturasParametroAsync(string parametro, int pageNumber, int pageSize);
        Task<CoberturaResumoResult> UpdateCobertura(CoberturaUpdateRequest cobertura);
    }
}
