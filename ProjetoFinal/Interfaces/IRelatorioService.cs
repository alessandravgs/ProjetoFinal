using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface IRelatorioService
    {
        Task<IEnumerable<PacienteCurativoRelatorio>> RelatorioCurativosTotalPacienteAsync(int idPaciente);
        Task<IEnumerable<PacienteCurativoRelatorio>> RelatorioCurativosPacientePeriodoAsync(int idPaciente, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<ProfissionalCurativoRelatorio>> RelatorioCurativosByProfissionalPeriodoAsync(int idProfissional, DateTime dataInicio, DateTime dataFinal);
        Task<IEnumerable<LesaoCurativoRelatorio>> RelatorioCurativosByLesaoAsync(int idLesao);
    }
}
