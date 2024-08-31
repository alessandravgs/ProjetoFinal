using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using System.Linq.Expressions;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioCurativo: IRepositorioCurativo
    {
        private readonly ApiDbContext _context;
        public RepositorioCurativo(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Curativo?> GetCurativoByCondicaoAsync(Expression<Func<Curativo, bool>> condicao)
        {
            return await _context.Curativos.FirstOrDefaultAsync(condicao);
        }

        public async Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Expression<Func<Curativo, bool>> condicao)
        {
            return await _context.Curativos.Where(condicao).ToListAsync();
        }

        public async Task<bool> SaveCurativoAsync(Curativo curativo)
        {
            try
            {
                _context.Curativos.Add(curativo);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<CurativoResumoResult>> GetUltimosCurativos(int idProfissional)
        {
            return await _context.Curativos.Where(x => x.Profissional.Id == idProfissional)
                .OrderByDescending(x => x.Data)
                .Take(5)
                .Select(x => new CurativoResumoResult
                {
                    Id = x.Id,
                    Lesao = x.Lesao.Detalhes,
                    Paciente = x.Lesao.Paciente.Nome,
                    Data = x.Data
                })
                .ToListAsync();
        }

        public async Task<PaginacaoResult<CurativoResumoResult>> GetCurativosByProfissionalAsync(int idProfissional, int pageNumber, int pageSize)
        {
            var query = _context.Curativos.Where(x => x.Profissional.Id == idProfissional).OrderByDescending(x => x.Data);
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CurativoResumoResult
                {
                    Id = x.Id,
                    Lesao = x.Lesao.Detalhes,
                    Paciente = x.Lesao.Paciente.Nome,
                    Data = x.Data
                })
                .ToListAsync();

            return new PaginacaoResult<CurativoResumoResult>()
            {
                TotalItems = totalItems,
                Items = items,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<IEnumerable<PacienteCurativoRelatorio>> GetRelatorioCurativosTotaisPacienteAsync(int idPaciente)
        {
            var consulta = _context.Curativos.Where(x => x.Lesao.Paciente.Id == idPaciente);
            return await GetPacienteCurativoRelatorio(consulta);
        }

        public async Task<IEnumerable<PacienteCurativoRelatorio>> GetRelatorioCurativosPorPeriodoPacienteAsync(int idPaciente, DateTime dataInicial, DateTime dataFinal)
        {
            var consulta = _context.Curativos.Where(x => x.Lesao.Paciente.Id == idPaciente && x.Data.Date >= dataInicial.Date && x.Data.Date <= dataInicial.Date);
            return await GetPacienteCurativoRelatorio(consulta);
        }

        private async Task<IEnumerable<PacienteCurativoRelatorio>> GetPacienteCurativoRelatorio(IQueryable<Curativo> consulta)
        {
            return await consulta.GroupBy(x => new { x.Lesao.Paciente.Nome, x.Lesao.Paciente.Sexo, x.Lesao.Paciente.DataNascimento })
                .Select(x => new PacienteCurativoRelatorio()
                {
                    NomePaciente = x.Key.Nome,
                    Sexo = x.Key.Sexo,
                    DataNascimento = x.Key.DataNascimento,
                    Curativos = x.Select(y => new DetalhesCurativoRelatorio
                    {
                        Coberturas = y.Coberturas.ToList(),
                        Data = y.Data,
                        Lesao = y.Lesao.Detalhes,
                        Observacoes = y.Observacoes,
                        Orientacoes = y.Orientacoes,
                        Profissional = y.Profissional.Nome,
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<IEnumerable<ProfissionalCurativoRelatorio>> GetRelatorioCurativosPorPeriodoProfissionalAsync(int idProfissional, DateTime dataInicial, DateTime dataFinal)
        {
            return await _context.Curativos.Where(x => x.Profissional.Id == idProfissional && x.Data.Date >= dataInicial.Date && x.Data.Date <= dataInicial.Date)
                .GroupBy(x => new { x.Profissional.Nome, x.Profissional.Cpf, x.Profissional.Email })
                .Select(x => new ProfissionalCurativoRelatorio
                {
                    NomeProfissional = x.Key.Nome,
                    CpfProfissional = x.Key.Cpf,
                    EmailProfissional = x.Key.Email,
                    Curativos = x.Select(y => new DetalhesCurativoProfissionalRelatorio
                    {
                        Coberturas = y.Coberturas.ToList(),
                        Data = y.Data,
                        Lesao = y.Lesao.Detalhes,
                        Observacoes = y.Observacoes,
                        Orientacoes = y.Orientacoes,
                        NomePaciente = y.Lesao.Paciente.Nome,
                        SexoPaciente = y.Lesao.Paciente.Sexo
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<IEnumerable<LesaoCurativoRelatorio>> GetRelatorioCurativosByLesao(int idLesao)
        {
            return await _context.Curativos.Where(x => x.Lesao.Id == idLesao)
                .GroupBy(x => new { x.Lesao.Detalhes, x.Lesao.Paciente.Nome, x.Lesao.Paciente.Sexo, x.Lesao.Paciente.DataNascimento })
                .Select(x => new LesaoCurativoRelatorio
                {
                    Lesao = x.Key.Detalhes,
                    NomePaciente = x.Key.Nome,
                    Sexo = x.Key.Sexo,
                    DataNascimento = x.Key.DataNascimento,
                    Curativos = x.Select(y => new CurativosLesaoDetalhes
                    {
                        Coberturas = y.Coberturas.ToList(),
                        Data = y.Data,
                        Observacoes = y.Observacoes,
                        Orientacoes = y.Orientacoes,
                        Profissional = y.Profissional.Nome,
                    }).ToList()
                }).ToListAsync();
        }

    }
}
