using ProjetoFinal.Models;
using ProjetoFinal.Models.Enums;
using ProjetoFinal.Requests.Coberturas;

namespace ProjetoFinal.Requests.Relatorios
{
    public class LesaoCurativoRelatorio
    {
        public string Lesao { get; set; }
        public string NomePaciente { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<CurativosLesaoDetalhes> Curativos { get; set; }

        public LesaoCurativoRelatorio()
        {
            Lesao = string.Empty;
            NomePaciente = string.Empty;
            Curativos = [];
        }
    }

    public class CurativosLesaoDetalhes
    {
        public string Profissional { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public string Orientacoes { get; set; }
        public virtual List<CoberturaResumida> Coberturas { get; set; }

        public CurativosLesaoDetalhes()
        {
            Profissional = string.Empty;
            Orientacoes = string.Empty;
            Observacoes = string.Empty;
            Coberturas = [];
        }
    }
}
