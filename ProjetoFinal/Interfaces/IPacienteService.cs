using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> RegistrarPacienteAsync(RegisterPacienteRequest pacienteRequest);
        Task<Paciente?> GetPacienteAsync(string parametro);
        Task<PaginacaoResult<PacienteResumoResult>> GetPagedPacientesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize);
        Task<List<AlergiaComorbidadeResumoResult>> GetAlergiasAsync();
        Task<List<AlergiaComorbidadeResumoResult>> GetComorbidadesAsync();
    }
}
