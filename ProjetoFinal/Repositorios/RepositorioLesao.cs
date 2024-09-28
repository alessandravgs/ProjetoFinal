using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Helpers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Lesao;
using ProjetoFinal.Requests.Paciente;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioLesao: IRepositorioLesao
    {
        private readonly ApiDbContext _context;
        public RepositorioLesao(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<LesaoDto> SaveLesaoAsync(Lesao lesao, EvolucaoLesao evolucaoLesao)
        {
            try
            {
                _context.Lesoes.Add(lesao);
                await SaveEvolucaoAsync(lesao, evolucaoLesao);
                return GetLesaoDto(lesao, evolucaoLesao);
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("Erro ao salvar Lesão.");
            }
        }

        public async Task<EvolucaoLesao> SaveEvolucaoAsync(Lesao lesao, EvolucaoLesao evolucaoLesao)
        {
            try
            {
                _context.EvolucaoLesao.Add(evolucaoLesao);
                await _context.SaveChangesAsync();
                lesao.UltimaEvolucaoId = evolucaoLesao.Id;
                await _context.SaveChangesAsync();
                return evolucaoLesao;
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("Erro ao salvar Evolução da Lesão.");
            }
        }

        public async Task<LesaoDto> UpdateLesao(LesaoUpdateRequest lesao)
        {
            try
            {
                var lesaoExistente = await _context.Lesoes
                    .FirstOrDefaultAsync(p => p.Id == lesao.Id)
                    ?? throw new KeyNotFoundException("Lesão não encontrada.");

                lesaoExistente.Membro = lesao.Membro;
                lesaoExistente.Regiao = lesao.Regiao;
                lesaoExistente.LadoRegiao = lesao.LadoRegiao;
                lesaoExistente.Situacao = lesao.Situacao;
                lesaoExistente.Cirurgica = lesao.Cirurgica;
                lesaoExistente.Infectada = lesao.Infectada;
                lesaoExistente.UlceraVenosa = lesao.TipoUlcera;
                lesaoExistente.DeiscenciaCirurgica = lesao.DeiscenciaCirurgica;
                lesaoExistente.Hanseniase = lesao.Hanseniase;
                lesaoExistente.Miiase = lesao.Miiase;
                lesaoExistente.Amputacao = lesao.Amputacao;
                lesaoExistente.Desbridamento = lesao.Desbridamento;
                lesaoExistente.Traumatica = lesao.Traumatica;
                lesaoExistente.Detalhes = lesao.Detalhes;

                var evolucao = await UpdateEvolucaoLesao(lesaoExistente, lesao);
                await _context.SaveChangesAsync();

                return GetLesaoDto(lesaoExistente, evolucao);
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Erro ao atualizar lesão: " + ex.Message);
            }
        }

        public async Task<EvolucaoLesao> UpdateEvolucaoLesao(Lesao lesaoExistente, LesaoUpdateRequest lesao)
        {
            var evolucao = await GetEvolucaoLesaoAsync(lesaoExistente.UltimaEvolucaoId)
                ?? throw new KeyNotFoundException("Evolução não encontrada.");

            if (evolucao.Altura != lesao.Altura ||
                evolucao.Largura != lesao.Largura ||
                evolucao.Profundidade != lesao.Profundidade ||
                evolucao.Situacao != lesao.Situacao)
            {
                var evolucaoNova = new EvolucaoLesao()
                {
                    Altura = lesao.Altura,
                    Largura = lesao.Largura,
                    Profundidade = lesao.Profundidade,
                    Situacao = lesao.Situacao,
                };

                await SaveEvolucaoAsync(lesaoExistente, evolucaoNova);
                return evolucaoNova;
            }

            return evolucao;
        }

        public async Task<LesaoDto?> GetLesaoByIdAsync(int id)
        {
            var lesao = await _context.Lesoes
               .FirstOrDefaultAsync(p => p.Id == id);

            if (lesao == null)
            {
                return null;
            }

            var ultimaEvolucao = await GetEvolucaoLesaoAsync(lesao.UltimaEvolucaoId);

            if (ultimaEvolucao == null)
            {
                return null;
            }

            return GetLesaoDto(lesao, ultimaEvolucao);
        }

        public async Task<EvolucaoLesao?> GetEvolucaoLesaoAsync(int id)
        {
            return await _context.EvolucaoLesao
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public LesaoDto GetLesaoDto(Lesao lesao, EvolucaoLesao evolucaoLesao)
        {
            return new LesaoDto
            {
                Id = lesao.Id,
                Paciente = new PacienteLesaoDto()
                {
                    Id = lesao.Paciente.Id,
                    Nome = lesao.Paciente.Nome,
                    Cpf = lesao.Paciente.Cpf,
                    DataNascimento = lesao.Paciente.DataNascimento,
                    Sexo = lesao.Paciente.Sexo,
                },
                Membro = lesao.Membro,
                Regiao = lesao.Regiao,
                LadoRegiao = lesao.LadoRegiao,
                Situacao = lesao.Situacao,
                Cirurgica = lesao.Cirurgica,
                Infectada = lesao.Infectada,
                TipoUlcera = lesao.UlceraVenosa,
                DeiscenciaCirurgica = lesao.DeiscenciaCirurgica,
                Hanseniase = lesao.Hanseniase,
                Miiase = lesao.Miiase,
                Amputacao = lesao.Amputacao,
                Desbridamento = lesao.Desbridamento,
                Traumatica = lesao.Traumatica,
                Detalhes = lesao.Detalhes,
                Altura = evolucaoLesao.Altura,
                Largura = evolucaoLesao.Largura,
                Profundidade = evolucaoLesao.Profundidade
            };
        }

        public async Task<PaginacaoResult<LesaoResumoResult>> GetLesoesByProfissional(int idProfissional, int pageNumber, int pageSize)
        {
            var query = _context.Curativos.Where(x => x.Profissional != null &&  x.Profissional.Id == idProfissional)
                .Select(x => x.Lesao).Distinct();
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new LesaoResumoResult()
                {
                    Id = x.Id,
                    Detalhes = x.Detalhes,
                    Paciente = x.Paciente.Nome,
                    Regiao = x.Regiao,
                    PacienteCpf = x.Paciente.Cpf,
                    LadoRegiao = x.LadoRegiao,
                    Situacao = x.Situacao,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<LesaoResumoResult>> GetLesoesParametroPacienteAsync(string parametro, int pageNumber, int pageSize)
        {
            var query = _context.Lesoes.AsQueryable();

            if (StringHelpers.IsValidCPF(parametro))
            {
                parametro = parametro.GetFormattedCpf();
                query = query.Where(x => x.Paciente.Cpf == parametro).OrderBy(x => x.Detalhes);
            }
            else
            {
                parametro = parametro.ToLower();
                query = query.Where(x => x.Paciente.Nome.ToLower().Contains(parametro)).OrderBy(x => x.Detalhes);
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new LesaoResumoResult()
                {
                    Id = x.Id,
                    Detalhes = x.Detalhes,
                    Paciente = x.Paciente.Nome,
                    Regiao = x.Regiao,
                    PacienteCpf = x.Paciente.Cpf,
                    LadoRegiao = x.LadoRegiao,
                    Situacao = x.Situacao,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<LesaoResumoResult>> GetLesoesByPacienteAsync(int idPaciente, int pageNumber, int pageSize)
        {
            var query = _context.Lesoes.AsQueryable().Where(x => x.Paciente.Id == idPaciente);

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new LesaoResumoResult()
                {
                    Id = x.Id,
                    Detalhes = x.Detalhes,
                    Paciente = x.Paciente.Nome,
                    Regiao = x.Regiao,
                    PacienteCpf = x.Paciente.Cpf,
                    LadoRegiao = x.LadoRegiao,
                    Situacao = x.Situacao,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public PaginacaoResult<LesaoResumoResult> RetornarPaginacao(int totalItems, List<LesaoResumoResult> lesoes, int pageNumber, int pageSize)
        {
            return new PaginacaoResult<LesaoResumoResult>()
            {
                TotalItems = totalItems,
                Items = lesoes,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Lesao?> GetLesaoFromPaciente(int pacienteID, int lesaoId)
        {
            var lesaoPaciente = await _context.Lesoes
                .FirstOrDefaultAsync(x => x.Paciente.Id == pacienteID && x.Id == lesaoId);

            return lesaoPaciente;
        }
    }
}
