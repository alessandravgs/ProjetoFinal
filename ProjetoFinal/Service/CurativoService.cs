using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Helpers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Repositorios;
using ProjetoFinal.Requests;
using ProjetoFinal.Requests.Curativo;
using ProjetoFinal.Requests.Lesao;

namespace ProjetoFinal.Service
{
    public class CurativoService : ICurativoService
    {
        private readonly IRepositorioCurativo _repositorio;
        private readonly IRepositorioPaciente _repositorioPaciente;
        private readonly IRepositorioLesao _repositorioLesao;
        private readonly IRepositorioCobertura _repositorioCobertura;
        private readonly IConfiguration _configuration;

        public CurativoService(IRepositorioCurativo repositorioCurativo, IRepositorioPaciente repositorioPaciente,
            IRepositorioLesao repositorioLesao, IRepositorioCobertura repositorioCobertura, IConfiguration configuration)
        {
            _repositorio = repositorioCurativo;
            _configuration = configuration;
            _repositorioPaciente = repositorioPaciente;
            _repositorioLesao = repositorioLesao;
            _repositorioCobertura = repositorioCobertura;
        }

        public async Task<int> RegistrarCurativoAsync(RegisterCurativoRequest curativo)
        {
            var paciente = await _repositorioPaciente.GetPacienteByCondicaoAsync(x => x.Id == curativo.PacienteId)
                ?? throw new ArgumentException("Não foi encontrado o paciente informado.");

            var lesao = await _repositorioLesao.GetLesaoFromPaciente(paciente.Id, curativo.LesaoId)
                 ?? throw new ArgumentException("Não foi encontrada a lesão informada para o paciente escolhido.");

            if (curativo.CoberturasIds.Count == 0)
                throw new ArgumentException("É necessário selecionar ao menos uma cobertura para o curativo.");

            var novaEvolucao = new EvolucaoLesao()
            {
                Altura = curativo.Altura,
                Profundidade = curativo.Profundidade,
                Largura = curativo.Largura,
                Situacao = curativo.SituacaoLesao,
                DataAtualizacao = DateTimeHelpers.ObterHoraBrasilia(),
                Lesao = lesao,
            };

            var novoCurativo = new Curativo()
            {
                Lesao = lesao,
                EvolucaoLesao = novaEvolucao,
                Observacoes = curativo.Observacoes,
                Orientacoes = curativo.Orientacoes,
                Data = DateTimeHelpers.ObterHoraBrasilia(),
                Coberturas = await _repositorioCobertura.GetCoberturasByListIdAsync(curativo.CoberturasIds)
            };

            lesao.Situacao = curativo.SituacaoLesao;

         
            PrepararImagensCurativo(novoCurativo, curativo);

            return await _repositorio.SaveCurativoAsync(novoCurativo, novaEvolucao);
        }

        public List<byte[]> PegarListaBytesFotos(RegisterCurativoRequest curativo)
        {
            List<byte[]> fotosBytes = new List<byte[]>();

            if (curativo.Fotos != null && curativo.Fotos.Count != 0)
            {
                foreach (var fotoBase64 in curativo.Fotos)
                {
                    // Remove o prefixo 'data:image/...;base64,' se existir
                    var base64Data = fotoBase64.Split(',')[1];
                    fotosBytes.Add(Convert.FromBase64String(base64Data));
                }
            }

            return fotosBytes;
        }

        public void PrepararImagensCurativo(Curativo curativo, RegisterCurativoRequest curativoRequest)
        {
            var fotos = PegarListaBytesFotos(curativoRequest);

            if (fotos.Count > 0)
            {
                var imagensCurativo = new List<ImagemCurativo>();
                foreach (var fotoSalvar in fotos)
                {
                    var imagemCurativoNew = new ImagemCurativo()
                    {
                        Curativo = curativo,
                        Foto = fotoSalvar,
                    };

                    imagensCurativo.Add(imagemCurativoNew);
                }

                curativo.Imagens = imagensCurativo;
            }
        }

        public async Task<int> UpdateCurativoAsync(UpdateCurativoRequest curativoRequest)
        {
            var paciente = await _repositorioPaciente.GetPacienteByCondicaoAsync(x => x.Id == curativoRequest.PacienteId)
                ?? throw new ArgumentException("Não foi encontrado o paciente informado.");

            var lesao = await _repositorioLesao.GetLesaoFromPaciente(paciente.Id, curativoRequest.LesaoId)
                 ?? throw new ArgumentException("Não foi encontrada a lesão informada para o paciente escolhido.");

            if (curativoRequest.CoberturasIds.Count == 0)
                throw new ArgumentException("É necessário selecionar ao menos uma cobertura para o curativo.");

            return await _repositorio.UpdateCurativo(curativoRequest);
        }

        public async Task<CurativoDto?> GetCurativoById(int id)
        {
            return await _repositorio.GetCurativoByIdAsync(id);
        }

        public async Task<PaginacaoResult<CurativoResumoResult>> GetPagedCurativosByProfissionalAsync(int profissionalId, int pageNumber, int pageSize)
        {
            return await _repositorio.GetCurativosByProfissional(profissionalId, pageNumber, pageSize);
        }

        public async Task<PaginacaoResult<CurativoResumoResult>> GetPagesCurativosParametroAsync(string parametro, int pageNumber, int pageSize)
        {
            if (string.IsNullOrEmpty(parametro))
                throw new ArgumentNullException("Parametro de pesquisa não pode ser null ou vazio.");

            return await _repositorio.GetCurativosParametroPacienteAsync(parametro, pageNumber, pageSize);
        }

        public async Task<Curativo?> GetCurativoAsync(int parametro)
        {
            return await _repositorio.GetCurativoByCondicaoAsync(x => x.Id == parametro);
        }

        public async Task<IEnumerable<CurativoResumoResult>> GetUltimosCurativos(int idProfissional)
        {
            return await _repositorio.GetUltimosCurativos(idProfissional);
        }

        public async Task<PaginacaoResult<CurativoResumoResult>> GetPagesCurativosByProfissionalAsync(int profissionalId, int pageNumber, int pageSize)
        {
            return await _repositorio.GetCurativosByProfissionalAsync(profissionalId, pageNumber, pageSize);
        }

       
    }
}
