using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Paciente;
using System.Linq.Expressions;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioPaciente
    {
        Task<Paciente?> GetPacienteByCondicaoAsync(Expression<Func<Paciente, bool>> condicao);
        Task<PacienteDto?> GetPacienteByIdAsync(int id);
        Task<PacienteDto> SavePacienteAsync(Paciente paciente);
        Task<PacienteDto> UpdatePaciente(UpdatePacienteRequest paciente);
        Task<PaginacaoResult<PacienteResumoResult>> GetPacientesByProfissional(int idProfissional, int pageNumber, int pageSize);
        Task<PaginacaoResult<PacienteResumoResult>> GetPacientesParametroAsync(string parametro, int pageNumber, int pageSize);
        Task<List<AlergiaComorbidadeResumoResult>> GetAlergiasAsync();
        Task<List<AlergiaComorbidadeResumoResult>> GetComorbidadesAsync();
        Task<List<Alergia>> GetAlergiasByListIdAsync(List<int> alergiasId);
        Task<List<Comorbidade>> GetComorbidadesByListIdAsync(List<int> comorbidadesId);
    }
}
