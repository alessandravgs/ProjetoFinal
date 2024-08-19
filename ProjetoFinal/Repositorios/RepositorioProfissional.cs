using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Controllers;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioProfissional: IRepositorioProfissional
    {
        private readonly ApiDbContext _context;
        public RepositorioProfissional(ApiDbContext context) 
        {
            _context = context;
        }

        public async Task<Profissional?> GetProfissional(LoginModel login)
        {
            var profissional = await _context.Profissionais
                .FirstOrDefaultAsync(x => x.Email == login.Email && x.Senha == login.Senha);

            return profissional;
        }

        public async Task<bool> SaveProfissional(Profissional profissional)
        {
            try
            {
                _context.Profissionais.Add(profissional);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }

        public async Task<IEnumerable<Curativo>> GetCurativosByProfissionalAsync(int id)
        {
            return await _context.Curativos.Where(c => c.Profissional.Id == id).ToListAsync();
        }

        public async Task<IEnumerable<Paciente>> GetPacientesByProfissional(int id)
        {
            return new List<Paciente>();
        }
    }
}
