using ProjetoFinal.Helpers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Lesao;
using ProjetoFinal.Requests.Paciente;

namespace ProjetoFinal.Service
{
    public class LesaoService: ILesaoService
    {
        private readonly IRepositorioLesao _repositorio;
        private readonly IRepositorioPaciente _repositorioPaciente;
        private readonly IConfiguration _configuration;

        public LesaoService(IRepositorioLesao repositorioCurativo, IRepositorioPaciente repositorioPaciente, IConfiguration configuration)
        {
            _repositorio = repositorioCurativo;
            _configuration = configuration;
            _repositorioPaciente = repositorioPaciente;
        }

        public async Task<LesaoDto> RegistrarLesaoAsync(RegisterLesaoRequest lesaoRequest)
        {
            var paciente = await _repositorioPaciente.GetPacienteByCondicaoAsync(x => x.Id == lesaoRequest.PacienteId);

            if (paciente == null)
                throw new FileNotFoundException("Paciente não encontrado.");

            var lesao = new Lesao()
            {
                Paciente = paciente,
                Amputacao = lesaoRequest.Amputacao,
                Cirurgica = lesaoRequest.Cirurgica,
                DeiscenciaCirurgica = lesaoRequest.DeiscenciaCirurgica,
                Desbridamento = lesaoRequest.Desbridamento,
                Detalhes = lesaoRequest.Detalhes,
                Hanseniase = lesaoRequest.Hanseniase,
                Infectada = lesaoRequest.Infectada,
                LadoRegiao = lesaoRequest.LadoRegiao,
                Membro = lesaoRequest.Membro,
                Miiase = lesaoRequest.Miiase,
                Regiao = lesaoRequest.Regiao,
                Situacao = lesaoRequest.Situacao,
                Traumatica = lesaoRequest.Traumatica,
                UlceraVenosa = lesaoRequest.TipoUlcera
            };

            var evolucao = new EvolucaoLesao()
            {
                Altura = lesaoRequest.Altura,
                Largura = lesaoRequest.Largura,
                Profundidade = lesaoRequest.Profundidade,
                Situacao = lesaoRequest.Situacao,
                Lesao = lesao,
                CurativoId = null,
                DataAtualizacao = DateTimeHelpers.ObterHoraBrasilia(),
            };

            return await _repositorio.SaveLesaoAsync(lesao, evolucao);
        }

        public async Task<LesaoDto> UpdateLesaoAsync(LesaoUpdateRequest lesaoRequest)
        {
            var paciente = await _repositorioPaciente.GetPacienteByCondicaoAsync(x => x.Id == lesaoRequest.PacienteId);
            if (paciente == null)
                throw new FileNotFoundException("Paciente não encontrado.");

            return await _repositorio.UpdateLesao(lesaoRequest);
        }

        public async Task<LesaoDto?> GetLesaoByIdAsync(int id)
        {
            return await _repositorio.GetLesaoByIdAsync(id);
        }

        public async Task<PaginacaoResult<LesaoResumoResult>> GetPagedLesoesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize)
        {
            return await _repositorio.GetLesoesByProfissional(profissionalId, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<LesaoResumoResult>> GetPagesLesaoParametroAsync(string parametro, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(parametro))
                throw new ArgumentNullException("Parametro de pesquisa não pode ser null ou vazio.");

            return await _repositorio.GetLesoesParametroPacienteAsync(parametro, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<LesaoResumoResult>> GetPagesLesaoByPacienteAsync(int idPaciente, int pageNumber, int pageSize)
        {
            return await _repositorio.GetLesoesByPacienteAsync(idPaciente, pageNumber, pageSize);
        }
    }
}
