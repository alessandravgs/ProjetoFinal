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
        public string Cpf { get; set; }
        public string Contato { get; set; }

        public LesaoCurativoRelatorio()
        {
            Lesao = string.Empty;
            NomePaciente = string.Empty;
            Cpf = string.Empty;
            Contato = string.Empty; 
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
        public Situacao Situacao { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Profundidade { get; set; }

        public CurativosLesaoDetalhes()
        {
            Profissional = string.Empty;
            Orientacoes = string.Empty;
            Observacoes = string.Empty;
            Coberturas = [];
        }
    }
}
