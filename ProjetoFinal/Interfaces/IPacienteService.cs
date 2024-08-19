using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IPacienteService
    {
        Task RegistrarPacienteAsync(Paciente paciente);
        Task<Paciente?> GetPacienteAsync(string parametro);
    }
}
