using ProjetoFinal.Controllers;
using ProjetoFinal.Models;
using ProjetoFinal.Requests.Profissional;

namespace ProjetoFinal.Interfaces
{
    public interface IProfissionalService
    {
        Task<string> LoginProfissionalAsync(LoginModel login);
        Task<ProfissionalDto?> GetProfissionalById(int id);
        Task<ProfissionalDto> UpdateProfissionalAsync(ProfissionalDto profissionalAtualizar, int id);
        Task RegistrarProfissionalAsync(RegisterProfissionalRequest profissional);
        Task<IEnumerable<Curativo>> GetCurativosByProfissionalIdAsync(int id);
        Task<IEnumerable<Paciente>> GetPacientesByProfissionalAsync(int id);
    }
}
