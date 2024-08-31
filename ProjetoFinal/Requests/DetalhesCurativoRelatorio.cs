using ProjetoFinal.Models;

namespace ProjetoFinal.Requests
{
    public class DetalhesCurativoRelatorio
    {
        public string Profissional { get; set; }
        public string Lesao { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public string Orientacoes { get; set; }
        public virtual List<Cobertura> Coberturas { get; set; }
    }
}
