using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface IPacienteService
    {
        Task RegistrarPacienteAsync(RegisterPacienteRequest paciente);
        Task<Paciente?> GetPacienteAsync(string parametro);
    }
}
