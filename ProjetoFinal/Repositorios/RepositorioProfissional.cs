using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests.Profissional;

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

        public async Task<ProfissionalDto?> GetProfissionalByIdAsync(int id)
        {
            var profissional = await _context.Profissionais
               .FirstOrDefaultAsync(p => p.Id == id);

            if (profissional == null)
            {
                return null;
            }

            return new ProfissionalDto
            {
                Nome = profissional.Nome,
                Cpf = profissional.Cpf,               
                Telefone = profissional.Telefone,
                Email = profissional.Email,
                Login = profissional.Login,
            };
        }

        public async Task<Profissional?> GetProfissionalBaseByIdAsync(int id)
        {
            var profissional = await _context.Profissionais
               .FirstOrDefaultAsync(p => p.Id == id);

            if (profissional == null)
            {
                return null;
            }

            return profissional;
        }

        public async Task<ProfissionalDto> UpdateProfissional(ProfissionalDto profissionalDto, int id)
        {
            try
            {
                var profissional = await _context.Profissionais.FindAsync(id)
                     ?? throw new KeyNotFoundException("Profissional não encontrado.");

                profissional.Nome = profissionalDto.Nome;
                profissional.Cpf = profissionalDto.Cpf;
                profissional.Telefone = profissionalDto.Telefone;
                profissional.Email = profissionalDto.Email;

                var loginExistente = await _context.Profissionais.AnyAsync(x => x.Login == profissionalDto.Login && x.Id != id);
                if (loginExistente)
                    throw new ArgumentException("Não é possível registrar esse login pois outra pessoa já está usando.");

                profissional.Login = profissionalDto.Login;
                await _context.SaveChangesAsync();

                return new ProfissionalDto()
                {
                    Nome = profissional.Nome,
                    Cpf = profissional.Cpf,
                    Telefone = profissional.Telefone,
                    Email = profissional.Email,
                    Login = profissional.Login,
                };
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Erro ao atualizar profissional: " + ex.Message);
            }
        }

        public async Task<IEnumerable<Curativo>> GetCurativosByProfissionalAsync(int id)
        {
            return await _context.Curativos.Where(c => c.Profissional.Id == id).ToListAsync();
        }

        public IEnumerable<Paciente> GetPacientesByProfissional(int id)
        {
            return new List<Paciente>();
        }
    }
}
