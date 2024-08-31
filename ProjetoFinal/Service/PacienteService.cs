using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Repositorios;
using ProjetoFinal.Requests;
using System.Reflection.Metadata;

namespace ProjetoFinal.Service
{
    public class PacienteService: IPacienteService
    {
        private readonly IRepositorioPaciente _repositorio;
        private readonly IConfiguration _configuration;

        public PacienteService(IRepositorioPaciente repositorioPaciente, IConfiguration configuration)
        {
            _repositorio = repositorioPaciente;
            _configuration = configuration;
        }

        public async Task RegistrarPacienteAsync(RegisterPacienteRequest pacienteRequest)
        {
            var paciente = new Paciente()
            {
                Nome = pacienteRequest.Nome,
                Cpf = pacienteRequest.Cpf,
                DataNascimento = pacienteRequest.DataNascimento,
            };

            var salvou = await _repositorio.SavePacienteAsync(paciente);

            if (!salvou)
                throw new BadHttpRequestException("Erro ao Salvar Paciente.");
        }

        public async Task<Paciente?> GetPacienteAsync(string parametro)
        {
            return await _repositorio.GetPacienteByCondicaoAsync(x => x.Cpf == parametro);
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPagedPacientesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize)
        {
            return await _repositorio.GetPacientesByProfissional(profissionalId, pageNumber, pageSize);
        }
    }
}
