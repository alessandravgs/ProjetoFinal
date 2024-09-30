using ProjetoFinal.Models;
using ProjetoFinal.Models.Enums;
using ProjetoFinal.Requests.Coberturas;

namespace ProjetoFinal.Requests.Relatorios
{
    public class DetalhesCurativoRelatorio
    {
        public string Profissional { get; set; }
        public string Lesao { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public string Orientacoes { get; set; }
        public Situacao Situacao { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Profundidade { get; set; }
        public virtual List<CoberturaResumida> Coberturas { get; set; }
        public List<string> Fotos { get; set; }
        public List<byte[]> FotosByte { get; set; }

        public DetalhesCurativoRelatorio()
        {
            Profissional = string.Empty;
            Lesao = string.Empty;
            Observacoes = string.Empty;
            Orientacoes = string.Empty;
            Coberturas = [];
            Fotos = [];
            FotosByte = [];
        }
    }
}
