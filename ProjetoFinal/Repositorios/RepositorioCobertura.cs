using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;

namespace ProjetoFinal.Repositorios
{
    public class RepositorioCobertura: IRepositorioCobertura
    {
        private readonly ApiDbContext _context;
        public RepositorioCobertura(ApiDbContext context)
        {
            _context = context;
        }

        public async Task <CoberturaResumoResult> SaveCobertura(Cobertura cobertura)
        {
            try
            {
                _context.Coberturas.Add(cobertura);
                await _context.SaveChangesAsync();
                return new CoberturaResumoResult() 
                { 
                    Id = cobertura.Id,
                    Nome = cobertura.Nome,
                    Descricao = cobertura.Descricao,
                };
            }
            catch (Exception)
            {
                throw new BadHttpRequestException("Erro ao salvar cobertura.");
            }
        }

        public async Task<CoberturaResumoResult> UpdateCobertura(CoberturaUpdateRequest cobertura)
        {
            try
            {
               var existingCobertura = await _context.Coberturas.FindAsync(cobertura.Id) 
                    ?? throw new KeyNotFoundException("Cobertura não encontrada.");
               
               existingCobertura.Nome = cobertura.Nome;
               existingCobertura.Descricao = cobertura.Descricao;                                                 
               await _context.SaveChangesAsync();
                return new CoberturaResumoResult()
                {
                    Id = existingCobertura.Id,
                    Nome = existingCobertura.Nome,
                    Descricao = existingCobertura.Descricao,
                };
            }
            catch (Exception ex)
            {
                throw new BadHttpRequestException("Erro ao atualizar cobertura: " + ex.Message);
            }
        }


        public async Task<PaginacaoResult<CoberturaResumoResult>> GetCoberturasParametroAsync(string parametro, int pageNumber, int pageSize)
        {
            string parametroLower = parametro.ToLower();

            var query = _context.Coberturas
                .Where(x => x.Nome.ToLower().Contains(parametroLower)).OrderBy(x => x.Nome);

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CoberturaResumoResult()
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Nome = x.Nome,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<CoberturaResumoResult>> GetCoberturasAsync(int pageNumber, int pageSize)
        {
            var query = _context.Coberturas.OrderBy(x => x.Nome);
            var totalItems = await query.CountAsync();
            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new CoberturaResumoResult()
                {
                    Id = x.Id,
                    Descricao = x.Descricao,
                    Nome = x.Nome,
                })
                .ToListAsync();

            return RetornarPaginacao(totalItems, items, pageNumber, pageSize);
        }

        public PaginacaoResult<CoberturaResumoResult> RetornarPaginacao (int totalItems, List<CoberturaResumoResult> coberturas, int pageNumber, int pageSize)
        {
            return new PaginacaoResult<CoberturaResumoResult>()
            {
                TotalItems = totalItems,
                Items = coberturas,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
