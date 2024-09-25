using ProjetoFinal.Helpers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Repositorios;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Paciente;
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

        public async Task<PacienteDto> RegistrarPacienteAsync(RegisterPacienteRequest pacienteRequest)
        {
            if (!StringHelpers.IsValidCPF(pacienteRequest.Cpf))
                throw new ArgumentException("Cpf informado é inválido.");

            var paciente = new Paciente()
            {
                Nome = pacienteRequest.Nome,
                Cpf = pacienteRequest.Cpf.GetFormattedCpf(),
                DataNascimento = pacienteRequest.DataNascimento,
                Sexo = pacienteRequest.Sexo,
                Telefone = StringHelpers.FormatTelefoneMovel(pacienteRequest.ddd, pacienteRequest.Telefone),
                Email = pacienteRequest.Email,
            };

            if (pacienteRequest.Alergias.Any() && pacienteRequest.Alergias != null)
                paciente.Alergias = await _repositorio.GetAlergiasByListIdAsync(pacienteRequest.Alergias);

            if (pacienteRequest.Comorbidades.Any() && pacienteRequest.Comorbidades != null)
                paciente.Comorbidades = await _repositorio.GetComorbidadesByListIdAsync(pacienteRequest.Comorbidades);

            return await _repositorio.SavePacienteAsync(paciente);
        }

        public async Task<PacienteDto> UpdatePacienteAsync(UpdatePacienteRequest pacienteRequest)
        {
            if (!StringHelpers.IsValidCPF(pacienteRequest.Cpf))
                throw new ArgumentException("Cpf informado é inválido.");

            return await _repositorio.UpdatePaciente(pacienteRequest);
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPagesPacienteParametroAsync(string parametro, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(parametro))
                throw new ArgumentNullException("Parametro de pesquisa não pode ser null ou vazio.");

            return await _repositorio.GetPacientesParametroAsync(parametro, pageNumber, pageSize);
        }

        public async Task<Paciente?> GetPacienteAsync(string parametro)
        {
            return await _repositorio.GetPacienteByCondicaoAsync(x => x.Cpf == parametro);
        }

        public async Task<PacienteDto?> GetPacienteByIdAsync(int id)
        {
            return await _repositorio.GetPacienteByIdAsync(id);
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPagedPacientesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize)
        {
            return await _repositorio.GetPacientesByProfissional(profissionalId, pageNumber, pageSize);
        }

        public async Task<List<AlergiaComorbidadeResumoResult>> GetAlergiasAsync()
        {
            return await _repositorio.GetAlergiasAsync();
        }

        public async Task<List<AlergiaComorbidadeResumoResult>> GetComorbidadesAsync()
        {
            return await _repositorio.GetComorbidadesAsync();
        }
    }
}
