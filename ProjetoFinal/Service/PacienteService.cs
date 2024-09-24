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

        public async Task<Paciente> RegistrarPacienteAsync(RegisterPacienteRequest pacienteRequest)
        {
            var paciente = new Paciente()
            {
                Nome = pacienteRequest.Nome,
                Cpf = pacienteRequest.Cpf,
                DataNascimento = pacienteRequest.DataNascimento,
                Sexo = pacienteRequest.Sexo,
                Telefone = pacienteRequest.Telefone,
                Email = pacienteRequest.Email,
            };

            if (pacienteRequest.Alergias.Any() && pacienteRequest.Alergias != null)
                paciente.Alergias = await _repositorio.GetAlergiasByListIdAsync(pacienteRequest.Alergias);

            if (pacienteRequest.Comorbidades.Any() && pacienteRequest.Comorbidades != null)
                paciente.Comorbidades = await _repositorio.GetComorbidadesByListIdAsync(pacienteRequest.Comorbidades);

            return await _repositorio.SavePacienteAsync(paciente);
        }

        public async Task<Paciente?> GetPacienteAsync(string parametro)
        {
            return await _repositorio.GetPacienteByCondicaoAsync(x => x.Cpf == parametro);
        }

        public async Task<PaginacaoResult<PacienteResumoResult>> GetPagedPacientesByProfissionalAsync(int profissionalId, int pageNumber, int pageSize)
        {
            return await _repositorio.GetPacientesByProfissional(profissionalId, pageNumber, pageSize);
        }

        public async Task<List<Alergia>> GetAlergiasAsync()
        {
            return await _repositorio.GetAlergiasAsync();
        }

        public async Task<List<Comorbidade>> GetComorbidadesAsync()
        {
            return await _repositorio.GetComorbidadesAsync();
        }
    }
}
