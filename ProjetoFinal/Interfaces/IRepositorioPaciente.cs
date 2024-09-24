using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using System.Linq.Expressions;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioPaciente
    {
        Task<Paciente?> GetPacienteByCondicaoAsync(Expression<Func<Paciente, bool>> condicao);
        Task<Paciente> SavePacienteAsync(Paciente paciente);
        Task<PaginacaoResult<PacienteResumoResult>> GetPacientesByProfissional(int idProfissional, int pageNumber, int pageSize);
        Task<List<AlergiaComorbidadeResumoResult>> GetAlergiasAsync();
        Task<List<AlergiaComorbidadeResumoResult>> GetComorbidadesAsync();
        Task<List<Alergia>> GetAlergiasByListIdAsync(List<int> alergiasId);
        Task<List<Comorbidade>> GetComorbidadesByListIdAsync(List<int> comorbidadesId);
    }
}
