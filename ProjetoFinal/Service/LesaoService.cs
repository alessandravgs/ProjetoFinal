using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests;

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

        public async Task RegistrarLesaoAsync(RegisterLesaoRequest lesaoRequest)
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

            var salvou = await _repositorio.SaveLesaoAsync(lesao);

            if (!salvou)
                throw new BadHttpRequestException("Erro ao Salvar Lesão.");
        }
    }
}
