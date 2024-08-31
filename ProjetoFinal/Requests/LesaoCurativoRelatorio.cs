using ProjetoFinal.Models;
using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests
{
    public class LesaoCurativoRelatorio
    {
        public string Lesao { get; set; }
        public string NomePaciente { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<CurativosLesaoDetalhes> Curativos { get; set; }
    }

    public class CurativosLesaoDetalhes
    {
        public string Profissional { get; set; }
        public DateTime Data { get; set; }
        public string Observacoes { get; set; }
        public string Orientacoes { get; set; }
        public virtual List<Cobertura> Coberturas { get; set; }
    }
}
