using ProjetoFinal.Models;
using System.Linq.Expressions;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioPaciente
    {
        Task<Paciente?> GetPacienteByCondicaoAsync(Expression<Func<Paciente, bool>> condicao);
        Task<bool> SavePacienteAsync(Paciente paciente);
    }
}
