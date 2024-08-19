using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;

namespace ProjetoFinal.Service
{
    public class CurativoService: ICurativoService
    {
        private readonly IRepositorioCurativo _repositorio;
        private readonly IConfiguration _configuration;

        public CurativoService(IRepositorioCurativo repositorioCurativo, IConfiguration configuration)
        {
            _repositorio = repositorioCurativo;
            _configuration = configuration;
        }

        public async Task RegistrarCurativoAsync(Curativo curativo)
        {
            var salvou = await _repositorio.SaveCurativoAsync(curativo);

            if (!salvou)
                throw new BadHttpRequestException("Erro ao Salvar Curativo.");
        }

        public async Task<Curativo?> GetCurativoAsync(string parametro)
        {
            return await _repositorio.GetCurativoByCondicaoAsync(x => x.Observacoes == parametro);
        }
    }
}
