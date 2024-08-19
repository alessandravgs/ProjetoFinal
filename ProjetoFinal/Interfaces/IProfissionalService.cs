using ProjetoFinal.Controllers;
using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IProfissionalService
    {
        Task<string> LoginProfissionalAsync(LoginModel login);
        Task RegistrarProfissionalAsync(Profissional profissional);
        Task<IEnumerable<Curativo>> GetCurativosByProfissionalIdAsync(int id);
        Task<IEnumerable<Paciente>> GetPacientesByProfissionalAsync(int id);
    }
}
