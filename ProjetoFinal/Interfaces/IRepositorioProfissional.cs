using ProjetoFinal.Models;
using ProjetoFinal.Requests.Profissional;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioProfissional
    {
        Task<Profissional?> GetProfissional(LoginModel login);

        Task<ProfissionalDto?> GetProfissionalByIdAsync(int id);

        Task<Profissional?> GetProfissionalBaseByIdAsync(int id);

        Task<ProfissionalDto> UpdateProfissional(ProfissionalDto profissionalDto, int id);

        Task<bool> SaveProfissional(Profissional profissional);

        Task<IEnumerable<Curativo>> GetCurativosByProfissionalAsync(int id);

        IEnumerable<Paciente> GetPacientesByProfissional(int id);
    }
}
