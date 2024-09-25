using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Helpers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Paciente;
using System.Linq.Expressions;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioPaciente : IRepositorioPaciente
    {
        private readonly ApiDbContext _context;
        public RepositorioPaciente(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Paciente?> GetPacienteByCondicaoAsync(Expression<Func<Paciente, bool>> condicao)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(condicao);
        }

        public async Task<PacienteDto?> GetPacienteByIdAsync(int id)
        {
            var paciente = await _context.Pacientes
               .Include(p => p.Alergias)
               .Include(p => p.Comorbidades)
               .FirstOrDefaultAsync(p => p.Id == id);

            if (paciente == null)
            {
                return null;
            }

            return new PacienteDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Cpf = paciente.Cpf,
                DataNascimento = paciente.DataNascimento,
                Sexo = paciente.Sexo,
                Telefone = paciente.Telefone,
                Email = paciente.Email,
                Alergias = paciente.Alergias.Select(a => new AlergiaDto { Id = a.Id, Nome = a.Nome }).ToList(),
                Comorbidades = paciente.Comorbidades.Select(c => new ComorbidadeDto { Id = c.Id, Nome = c.Nome }).ToList()
            };
        }

        public async Task<PacienteDto> SavePacienteAsync(Paciente paciente)
        {
            try
            {
                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync();

                return GetPacienteDto(paciente);
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("Erro ao salvar Paciente.");
            }
        }

        public async Task<PacienteDto> UpdatePaciente(UpdatePacienteRequest paciente)
        {
            try
            {
                var pacienteExistente = await _context.Pacientes
                    .Include(p => p.Alergias) 
                    .Include(p => p.Comorbidades) 
                    .FirstOrDefaultAsync(p => p.Id == paciente.Id)
                    ?? throw new KeyNotFoundException("Paciente não encontrado.");

                pacienteExistente.Nome = paciente.Nome;
                pacienteExistente.Cpf = paciente.Cpf.GetFormattedCpf();
                pacienteExistente.DataNascimento = paciente.DataNascimento;
                pacienteExistente.Sexo = paciente.Sexo;
                pacienteExistente.Telefone = StringHelpers.FormatTelefoneMovel(paciente.ddd, paciente.Telefone);
                pacienteExistente.Email = paciente.Email;

                await AtualizarComorbidadesAlergias(paciente, pacienteExistente);

                await _context.SaveChangesAsync();

                return GetPacienteDto(pacienteExistente);
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Erro ao atualizar cobertura: " + ex.Message);
            }
        }

        public async Task AtualizarComorbidadesAlergias(UpdatePacienteRequest paciente, Paciente pacienteExistente)
        {
            List<int> comorbidadesBase = pacienteExistente.Comorbidades.Select(x => x.Id).ToList();
            var comorbidadeToDelete = comorbidadesBase.Except(paciente.Comorbidades).ToList();
            var comorbidadeToAdd = paciente.Comorbidades.Except(comorbidadesBase).ToList();

            foreach(var deleteComorbidade in comorbidadeToDelete)
            {
                var apagar = pacienteExistente.Comorbidades.FirstOrDefault(x => x.Id == deleteComorbidade);
                if (apagar == null) continue;

                pacienteExistente.Comorbidades.Remove(apagar);
            }

            if(comorbidadeToAdd != null && comorbidadeToAdd.Any())
            {
                var comorbidadesAddBase = await GetComorbidadesByListIdAsync(comorbidadeToAdd);
                foreach (var inserirComorbidade in comorbidadesAddBase)
                {           
                    pacienteExistente.Comorbidades.Add(inserirComorbidade);
                }
            }

            List<int> alergiasBase = pacienteExistente.Alergias.Select(x => x.Id).ToList();
            var alergiasToDelete = alergiasBase.Except(paciente.Alergias).ToList();
            var alergiasToAdd = paciente.Alergias.Except(alergiasBase).ToList();

            foreach (var deleteAlergia in alergiasToDelete)
            {
                var apagar = pacienteExistente.Alergias.FirstOrDefault(x => x.Id == deleteAlergia);
                if (apagar == null) continue;

                pacienteExistente.Alergias.Remove(apagar);
            }

            if (alergiasToAdd != null && alergiasToAdd.Any())
            {
                var alergiasAddBase = await GetAlergiasByListIdAsync(alergiasToAdd);
                foreach (var inserirAlergia in alergiasAddBase)
                {
                    pacienteExistente.Alergias.Add(inserirAlergia);
                }
            }

        }

        public PacienteDto GetPacienteDto(Paciente paciente)
        {
            return new PacienteDto
            {
                Id = paciente.Id,
                Nome = paciente.Nome,
                Cpf = paciente.Cpf,
                DataNascimento = paciente.DataNascimento,
                Sexo = paciente.Sexo,
                Telefone = paciente.Telefone,
                Email = paciente.Email,
                Alergias = paciente.Alergias?.Select(a => new AlergiaDto { Id = a.Id, Nome = a.Nome }).ToList() ?? new List<AlergiaDto>(),
                Comorbidades = paciente.Comorbidades?.Select(c => new ComorbidadeDto { Id = c.Id, Nome = c.Nome }).ToList() ?? new List<ComorbidadeDto>()
            };
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPacientesByProfissional(int idProfissional, int pageNumber, int pageSize)
        {
            //var query = _context.Curativos.Where(x => x.Profissional.Id == idProfissional).Select(x => x.Lesao.Paciente).Distinct();
            var query =  _context.Pacientes.OrderBy(x => x.Nome);
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new PacienteResumoResult
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    Sexo = x.Sexo,
                    Cpf = x.Cpf,
                    Telefone = x.Telefone,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPacientesParametroAsync(string parametro, int pageNumber, int pageSize)
        {
            var query = _context.Pacientes.AsQueryable();

            if (StringHelpers.IsValidCPF(parametro))
            {
                parametro = parametro.GetFormattedCpf();
                query = query.Where(x => x.Cpf == parametro).OrderBy(x => x.Nome);
            }
            else
            {
                parametro = parametro.ToLower();
                query = query.Where(x => x.Nome.ToLower().Contains(parametro)).OrderBy(x => x.Nome);
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new PacienteResumoResult()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    DataNascimento = x.DataNascimento,
                    Sexo = x.Sexo,
                    Cpf = x.Cpf,
                    Telefone = x.Telefone,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public PaginacaoResult<PacienteResumoResult> RetornarPaginacao(int totalItems, List<PacienteResumoResult> coberturas, int pageNumber, int pageSize)
        {
            return new PaginacaoResult<PacienteResumoResult>()
            {
                TotalItems = totalItems,
                Items = coberturas,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<List<AlergiaComorbidadeResumoResult>> GetAlergiasAsync()
        {
            return await _context.Alergias
                .Select(x => new AlergiaComorbidadeResumoResult()
                {
                    Id = x.Id,
                    Nome = x.Nome
                })
                .ToListAsync();
        }

        public async Task<List<Alergia>> GetAlergiasByListIdAsync(List<int> alergiasId)
        {
            return await _context.Alergias
                .Where(a => alergiasId.Contains(a.Id))
                .ToListAsync();
        }

        public async Task<List<AlergiaComorbidadeResumoResult>> GetComorbidadesAsync()
        {
            return await _context.Comorbidades
                .Select(x => new AlergiaComorbidadeResumoResult()
                {
                    Id = x.Id,
                    Nome = x.Nome
                }).ToListAsync();
        }

        public async Task<List<Comorbidade>> GetComorbidadesByListIdAsync(List<int> comorbidadesId)
        {
            return await _context.Comorbidades
                .Where(a => comorbidadesId.Contains(a.Id))
                .ToListAsync();
        }

    }
}
