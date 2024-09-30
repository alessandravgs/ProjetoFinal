using ProjetoFinal.Models.Enums;
using ProjetoFinal.Requests.Coberturas;

namespace ProjetoFinal.Requests.Relatorios
{
    public class DetalhesCurativoProfissionalRelatorio
    {
        public string NomePaciente { get; set; }
        public Sexo SexoPaciente { get; set; }
        public string Lesao { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public string Orientacoes { get; set; }
        public virtual List<CoberturaResumida> Coberturas { get; set; }
        public Situacao Situacao { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Profundidade { get; set; }

        public DetalhesCurativoProfissionalRelatorio()
        {
            NomePaciente = string.Empty;
            Lesao = string.Empty;
            Observacoes = string.Empty;
            Orientacoes = string.Empty;
            Coberturas = [];
        }
    }
}
