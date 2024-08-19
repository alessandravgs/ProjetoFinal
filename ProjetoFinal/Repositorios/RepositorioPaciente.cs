using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using System.Linq;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioPaciente: IRepositorioPaciente
    {
        private readonly ApiDbContext _context;
        public RepositorioPaciente(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente?> GetPacienteByCondicaoAsync(Func<Paciente, bool> condicao)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => condicao(p));
        }

        public async Task<bool> SavePacienteAsync(Paciente paciente)
        {
            try
            {
                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
