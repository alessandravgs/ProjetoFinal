using ProjetoFinal.Models;
using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests
{
    public class DetalhesCurativoProfissionalRelatorio
    {
        public string NomePaciente { get; set; }
        public Sexo SexoPaciente { get; set; }
        public string Lesao { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public string Orientacoes { get; set; }
        public virtual List<Cobertura> Coberturas { get; set; }
    }
}
