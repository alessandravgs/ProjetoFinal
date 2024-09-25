using ProjetoFinal.Interfaces;
using ProjetoFinal.Requests.Relatorios;
using System.Collections.Generic;

namespace ProjetoFinal.Service
{
    public class RelatorioService: IRelatorioService
    {
        private readonly IRepositorioProfissional _repositorioProfissional;
        private readonly IRepositorioCurativo _repositorioCurativo;
        private readonly IRepositorioPaciente _repositorioPaciente;
        private readonly IConfiguration _configuration;

        public RelatorioService(IRepositorioProfissional repositorioProfissional, IRepositorioCurativo repositorioCurativo, IRepositorioPaciente repositorioPaciente, IConfiguration configuration)
        {
            _repositorioProfissional = repositorioProfissional;
            _repositorioCurativo = repositorioCurativo;
            _repositorioPaciente = repositorioPaciente;
            _configuration = configuration;
        }

        public async Task<IEnumerable<PacienteCurativoRelatorio>> RelatorioCurativosTotalPacienteAsync(int idPaciente)
        {
            await PacienteExisteNaBase(idPaciente);

            return await _repositorioCurativo.GetRelatorioCurativosTotaisPacienteAsync(idPaciente);
        }

        public async Task<IEnumerable<PacienteCurativoRelatorio>> RelatorioCurativosPacientePeriodoAsync(int idPaciente, DateTime dataInicio, DateTime dataFinal)
        {
            await PacienteExisteNaBase(idPaciente);
            return await _repositorioCurativo.GetRelatorioCurativosPorPeriodoPacienteAsync(idPaciente, dataInicio, dataFinal);
        }

        public async Task<IEnumerable<ProfissionalCurativoRelatorio>> RelatorioCurativosByProfissionalPeriodoAsync(int idProfissional, DateTime dataInicio, DateTime dataFinal)
        {
            return await _repositorioCurativo.GetRelatorioCurativosPorPeriodoProfissionalAsync(idProfissional, dataInicio, dataFinal);
        }

        public async Task<IEnumerable<LesaoCurativoRelatorio>> RelatorioCurativosByLesaoAsync(int idLesao)
        {
            return await _repositorioCurativo.GetRelatorioCurativosByLesao(idLesao);
        }

        public async Task PacienteExisteNaBase(int idPaciente)
        {
            var paciente = await _repositorioPaciente.GetPacienteByCondicaoAsync(x => x.Id == idPaciente);

            if (paciente == null)
                throw new FileNotFoundException("Paciente não encontrado.");
        }

    }
}
