using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Lesao;

namespace ProjetoFinal.Interfaces
{
    public interface ILesaoService
    {
        Task<LesaoDto> RegistrarLesaoAsync(RegisterLesaoRequest lesaoRequest);
        Task<LesaoDto> UpdateLesaoAsync(LesaoUpdateRequest lesaoRequest);
        Task<LesaoDto?> GetLesaoByIdAsync(int id);
        Task<PaginacaoResult<LesaoResumoResult>> GetPagedLesoesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize);
        Task<PaginacaoResult<LesaoResumoResult>> GetPagesLesaoParametroAsync(string parametro, int pageNumber, int pageSize);
        Task<PaginacaoResult<LesaoResumoResult>> GetPagesLesaoByPacienteAsync(int idPaciente, int pageNumber, int pageSize);
    }
}
