using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using System.Linq.Expressions;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioPaciente
    {
        Task<Paciente?> GetPacienteByCondicaoAsync(Expression<Func<Paciente, bool>> condicao);
        Task<bool> SavePacienteAsync(Paciente paciente);
        Task<PaginacaoResult<PacienteResumoResult>> GetPacientesByProfissional(int idProfissional, int pageNumber, int pageSize);
    }
}
