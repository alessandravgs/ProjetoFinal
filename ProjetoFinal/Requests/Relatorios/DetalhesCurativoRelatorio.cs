using ProjetoFinal.Models;
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
        public virtual List<CoberturaResumoResult> Coberturas { get; set; }

        public DetalhesCurativoRelatorio()
        {
            Profissional = string.Empty;
            Lesao = string.Empty;
            Observacoes = string.Empty;
            Orientacoes = string.Empty;
            Coberturas = [];
        }
    }
}
