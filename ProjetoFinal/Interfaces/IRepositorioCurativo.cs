using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Curativo;
using ProjetoFinal.Requests.Relatorios;
using System.Linq.Expressions;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioCurativo
    {
        Task<Curativo?> GetCurativoByCondicaoAsync(Expression<Func<Curativo, bool>> condicao);
        Task<CurativoDto?> GetCurativoByIdAsync(int id);
        Task<IEnumerable<Curativo>> GetListagemCurativosByCondicaoAsync(Expression<Func<Curativo, bool>> condicao);
        Task<int> SaveCurativoAsync(Curativo curativo, EvolucaoLesao evolucaoLesao);
        Task<int> UpdateCurativo(UpdateCurativoRequest curativo, int idProfissional);
        Task<PaginacaoResult<CurativoResumoResult>> GetCurativosParametroPacienteAsync(string parametro, int pageNumber, int pageSize);
        Task<PaginacaoResult<CurativoResumoResult>> GetCurativosByProfissional(int idProfissional, int pageNumber, int pageSize);
        Task<IEnumerable<CurativoResumoResult>> GetUltimosCurativos(int idProfissional);
        Task<PaginacaoResult<CurativoResumoResult>> GetCurativosByProfissionalAsync(int idProfissional, int pageNumber, int pageSize);
        Task<IEnumerable<PacienteCurativoRelatorio>> GetRelatorioCurativosTotaisPacienteAsync(int idPaciente);
        Task<IEnumerable<PacienteCurativoRelatorio>> GetRelatorioCurativosPorPeriodoPacienteAsync(int idPaciente, DateTime dataInicial, DateTime dataFinal);
        Task<IEnumerable<ProfissionalCurativoRelatorio>> GetRelatorioCurativosPorPeriodoProfissionalAsync(int idProfissional, DateTime dataInicial, DateTime dataFinal);
        Task<IEnumerable<LesaoCurativoRelatorio>> GetRelatorioCurativosByLesao(int idLesao);
    }
}
