using ProjetoFinal.Controllers;
using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioProfissional
    {
        Task<Profissional?> GetProfissional(LoginModel login);

        Task<bool> SaveProfissional(Profissional profissional);

        Task<IEnumerable<Curativo>> GetCurativosByProfissionalAsync(int id);

        Task<IEnumerable<Paciente>> GetPacientesByProfissional(int id);
    }
}
