using ProjetoFinal.Controllers;
using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IProfissionalService
    {
        Task<string> LoginProfissional(LoginModel login);
        Task RegistrarProfissional(Profissional profissional);
        Task<IEnumerable<Curativo>> GetCurativosByProfissionalId(int id);
        Task<IEnumerable<Paciente>> GetPacientesByProfissional(int id);
    }
}
