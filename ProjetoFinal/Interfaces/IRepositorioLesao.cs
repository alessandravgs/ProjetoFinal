using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Lesao;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioLesao
    {
        Task<LesaoDto> SaveLesaoAsync(Lesao lesao, EvolucaoLesao evolucaoLesao);
        Task<LesaoDto> UpdateLesao(LesaoUpdateRequest lesao);
        Task<LesaoDto?> GetLesaoByIdAsync(int id);
        Task<PaginacaoResult<LesaoResumoResult>> GetLesoesByProfissional(int idProfissional, int pageNumber, int pageSize);
        Task<PaginacaoResult<LesaoResumoResult>> GetLesoesParametroPacienteAsync(string parametro, int pageNumber, int pageSize);
        Task<PaginacaoResult<LesaoResumoResult>> GetLesoesByPacienteAsync(int idPaciente, int pageNumber, int pageSize);
    }
}
