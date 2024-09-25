using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Coberturas;

namespace ProjetoFinal.Service
{
    public class CoberturaService: ICoberturaService
    {
        private readonly IRepositorioCobertura _repositorio;
        private readonly IConfiguration _configuration;

        public CoberturaService(IRepositorioCobertura repositorioCurativo,  IConfiguration configuration)
        {
            _repositorio = repositorioCurativo;
            _configuration = configuration;
        }

        public async Task<CoberturaResumoResult> SaveCoberturaAsync(RegisterCobertura registerCobertura)
        {
            var cobertura = new Cobertura()
            {
                Nome = registerCobertura.Nome,
                Descricao = registerCobertura.Descricao,
            };

            return await _repositorio.SaveCobertura(cobertura);
        }

        public async Task<PaginacaoResult<CoberturaResumoResult>> GetPagesCoberturasAsync(int pageNumber, int pageSize)
        {
            return await _repositorio.GetCoberturasAsync(pageNumber, pageSize);
        }
        
        public async Task<PaginacaoResult<CoberturaResumoResult>> GetPagesCoberturasParametroAsync(string parametro, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(parametro))
                throw new ArgumentNullException("Parametro de pesquisa não pode ser null ou vazio.");

            return await _repositorio.GetCoberturasParametroAsync(parametro, pageNumber, pageSize);
        }

        public async Task<CoberturaResumoResult> UpdateCoberturaAsync(CoberturaUpdateRequest coberturaAtualizar)
        {
            return await _repositorio.UpdateCobertura(coberturaAtualizar);
        }
    }
}
