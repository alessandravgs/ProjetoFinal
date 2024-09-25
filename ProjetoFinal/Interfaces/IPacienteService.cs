using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Paciente;

namespace ProjetoFinal.Interfaces
{
    public interface IPacienteService
    {
        Task<PacienteDto> RegistrarPacienteAsync(RegisterPacienteRequest pacienteRequest);
        Task<PacienteDto> UpdatePacienteAsync(UpdatePacienteRequest pacienteRequest);
        Task<Paciente?> GetPacienteAsync(string parametro);
        Task<PacienteDto?> GetPacienteByIdAsync(int id);
        Task<PaginacaoResult<PacienteResumoResult>> GetPagedPacientesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize);
        Task<List<AlergiaComorbidadeResumoResult>> GetAlergiasAsync();
        Task<List<AlergiaComorbidadeResumoResult>> GetComorbidadesAsync();
        Task<PaginacaoResult<PacienteResumoResult>> GetPagesPacienteParametroAsync(string parametro, int pageNumber, int pageSize);
    }
}
