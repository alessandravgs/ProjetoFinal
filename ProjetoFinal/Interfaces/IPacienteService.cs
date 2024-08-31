using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface IPacienteService
    {
        Task RegistrarPacienteAsync(RegisterPacienteRequest paciente);
        Task<Paciente?> GetPacienteAsync(string parametro);
        Task<PaginacaoResult<PacienteResumoResult>> GetPagedPacientesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize);
    }
}
