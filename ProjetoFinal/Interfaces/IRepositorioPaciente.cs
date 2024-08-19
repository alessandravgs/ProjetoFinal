using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioPaciente
    {
        Task<Paciente?> GetPacienteByCondicaoAsync(Func<Paciente, bool> condicao);
        Task<bool> SavePacienteAsync(Paciente paciente);
    }
}
