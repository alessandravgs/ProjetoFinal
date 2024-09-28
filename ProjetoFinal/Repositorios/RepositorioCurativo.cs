using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Helpers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Coberturas;
using ProjetoFinal.Requests.Curativo;
using ProjetoFinal.Requests.Lesao;
using ProjetoFinal.Requests.Paciente;
using ProjetoFinal.Requests.Relatorios;
using System.Linq.Expressions;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioCurativo : IRepositorioCurativo
    {
        private readonly ApiDbContext _context;
        private readonly IRepositorioCobertura _repositorioCobertura;
        public RepositorioCurativo(ApiDbContext context, IRepositorioCobertura repositorioCobertura)
        {
            _context = context;
            _repositorioCobertura = repositorioCobertura;
        }

        public async Task<Curativo?> GetCurativoByCondicaoAsync(Expression<Func<Curativo, bool>> condicao)
        {
            return await _context.Curativos.FirstOrDefaultAsync(condicao);
        }

        public async Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Expression<Func<Curativo, bool>> condicao)
        {
            return await _context.Curativos.Where(condicao).ToListAsync();
        }

        public async Task<int> SaveCurativoAsync(Curativo curativo, EvolucaoLesao evolucaoLesao)
        {
            try
            {
                _context.EvolucaoLesao.Add(evolucaoLesao);
                _context.Curativos.Add(curativo);
                await _context.SaveChangesAsync();
                return curativo.Id;
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("Erro ao salvar curativo.");
            }
        }

        public async Task<CurativoDto?> GetCurativoByIdAsync(int id)
        {
            var curativo = await _context.Curativos.FirstOrDefaultAsync(x => x.Id == id);

            if (curativo == null)
                return null;

            return GetCurativoDto(curativo);
        }

        public CurativoDto GetCurativoDto(Curativo curativo)
        {
            var dto = new CurativoDto()
            {
                Id = curativo.Id,
                Data = curativo.Data,
                Detalhes = curativo.Observacoes,
                Orientacoes = curativo.Orientacoes,
                Paciente = new PacienteCurativoDto()
                {
                    Id = curativo.Lesao.Paciente.Id,
                    Nome = curativo.Lesao.Paciente.Nome,
                    Cpf = curativo.Lesao.Paciente.Cpf,
                    DataNascimento = curativo.Lesao.Paciente.DataNascimento,
                    Sexo = curativo.Lesao.Paciente.Sexo,
                    Telefone = curativo.Lesao.Paciente.Telefone,
                },
                Lesao = new LesaoCurativoDto()
                {
                    Id = curativo.Lesao.Id,
                    Detalhes = curativo.Lesao.Detalhes,
                    Situacao = curativo.Lesao.Situacao,
                    Amputacao = curativo.Lesao.Amputacao,
                    Cirurgica = curativo.Lesao.Cirurgica,
                    DeiscenciaCirurgica = curativo.Lesao.DeiscenciaCirurgica,
                    Desbridamento = curativo.Lesao.Desbridamento,
                    Hanseniase = curativo.Lesao.Hanseniase,
                    Infectada = curativo.Lesao.Infectada,
                    LadoRegiao = curativo.Lesao.LadoRegiao,
                    Membro = curativo.Lesao.Membro,
                    Miiase = curativo.Lesao.Miiase, 
                    Regiao = curativo.Lesao.Regiao,
                    TipoUlcera = curativo.Lesao.UlceraVenosa,
                    Traumatica = curativo.Lesao.Traumatica,                    
                },
                Evolucao = new EvolucaoLesaoCurativoDto()
                { 
                    Altura = curativo.EvolucaoLesao.Altura,
                    Profundidade = curativo.EvolucaoLesao.Profundidade,
                    Largura = curativo.EvolucaoLesao.Largura,
                }, 
                Coberturas = curativo.Coberturas.Select(x => new CoberturaResumoResult() { Id = x.Id, Nome = x.Nome, Descricao = x.Descricao}).ToList(),
                Fotos = (curativo.Imagens ?? new List<ImagemCurativo>()).Select(x => ConvertByteArrayToBase64(x.Foto)).ToList()
            };
            
            return dto;
        }

        public string ConvertByteArrayToBase64(byte[] byteArray)
        {
            if (byteArray == null || byteArray.Length == 0)
            {
                return string.Empty; 
            }

            return Convert.ToBase64String(byteArray);
        }

        public async Task<PaginacaoResult<CurativoResumoResult>> GetCurativosByProfissional(int idProfissional, int pageNumber, int pageSize)
        {
            //var query = _context.Curativos.Where(x => x.Profissional.Id == idProfissional).Select(x => x.Lesao.Paciente).Distinct();
            var query = _context.Curativos.OrderBy(x => x.Data);
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CurativoResumoResult()
                {
                    Id = x.Id,
                    Paciente = x.Lesao.Paciente.Nome,
                    Lesao = x.Lesao.Detalhes,
                    Data = x.Data,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<CurativoResumoResult>> GetCurativosParametroPacienteAsync(string parametro, int pageNumber, int pageSize)
        {
            var query = _context.Curativos.AsQueryable();

            if (StringHelpers.IsValidCPF(parametro))
            {
                parametro = parametro.GetFormattedCpf();
                query = query.Where(x => x.Lesao.Paciente.Cpf == parametro).OrderBy(x => x.Data);
            }
            else
            {
                parametro = parametro.ToLower();
                query = query.Where(x => x.Lesao.Paciente.Nome.ToLower().Contains(parametro)).OrderBy(x => x.Data);
            }

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CurativoResumoResult()
                {
                    Id = x.Id,
                    Paciente = x.Lesao.Paciente.Nome,
                    Lesao = x.Lesao.Detalhes,
                    Data = x.Data,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public PaginacaoResult<CurativoResumoResult> RetornarPaginacao(int totalItems, List<CurativoResumoResult> curativos, int pageNumber, int pageSize)
        {
            return new PaginacaoResult<CurativoResumoResult>()
            {
                TotalItems = totalItems,
                Items = curativos,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<int> UpdateCurativo(UpdateCurativoRequest curativo)
        {
            try
            {
                var curativoExistente = await _context.Curativos
                    .Include(p => p.Coberturas)
                    .FirstOrDefaultAsync(p => p.Id == curativo.Id)
                    ?? throw new KeyNotFoundException("Curativo não encontrado.");

                curativoExistente.EvolucaoLesao.Altura = curativo.Altura;
                curativoExistente.EvolucaoLesao.Profundidade = curativo.Profundidade;
                curativoExistente.EvolucaoLesao.Largura = curativo.Largura;
                curativoExistente.EvolucaoLesao.Situacao = curativo.SituacaoLesao;
                curativoExistente.Observacoes = curativo.Observacoes;
                curativoExistente.Orientacoes = curativo.Orientacoes;


                await AtualizarCoberturas(curativo, curativoExistente);

                PrepararImagensCurativo(curativoExistente, curativo);

                await _context.SaveChangesAsync();

                return curativo.Id;
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Erro ao atualizar curativo: " + ex.Message);
            }
        }

        public async Task AtualizarCoberturas(UpdateCurativoRequest curativo, Curativo curativoExistente)
        {
            List<int> coberturasBase = curativoExistente.Coberturas.Select(x => x.Id).ToList();
            var coberturasToDelete = coberturasBase.Except(curativo.CoberturasIds).ToList();
            var coberturasToAdd = curativo.CoberturasIds.Except(coberturasBase).ToList();

            foreach (var deleteCobertura in coberturasToDelete)
            {
                var apagar = curativoExistente.Coberturas.FirstOrDefault(x => x.Id == deleteCobertura);
                if (apagar == null) continue;

                curativoExistente.Coberturas.Remove(apagar);
            }

            if (coberturasToAdd != null && coberturasToAdd.Any())
            {
                var coberturasAddBase = await _repositorioCobertura.GetCoberturasByListIdAsync(coberturasToAdd);
                foreach (var inserirCobertura in coberturasAddBase)
                {
                    curativoExistente.Coberturas.Add(inserirCobertura);
                }
            }
        }

        public List<byte[]> PegarListaBytesFotos(UpdateCurativoRequest curativo)
        {
            List<byte[]> fotosBytes = new List<byte[]>();

            if (curativo.Fotos != null && curativo.Fotos.Count != 0)
            {
                foreach (var fotoBase64 in curativo.Fotos)
                {
                    // Remove o prefixo 'data:image/...;base64,' se existir
                    var base64Data = fotoBase64.Split(',')[1];
                    fotosBytes.Add(Convert.FromBase64String(base64Data));
                }
            }

            return fotosBytes;
        }

        public void PrepararImagensCurativo(Curativo curativo, UpdateCurativoRequest curativoRequest)
        {
            var fotos = PegarListaBytesFotos(curativoRequest);

            if (fotos.Count > 0)
            {
                foreach (var fotoSalvar in fotos)
                {
                    var imagemCurativoNew = new ImagemCurativo()
                    {
                        Curativo = curativo,
                        Foto = fotoSalvar,
                    };

                    curativo.Imagens.Add(imagemCurativoNew);
                }
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
