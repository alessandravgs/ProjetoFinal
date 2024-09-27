using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Models
{
    public class EvolucaoLesao
    {
        public int Id { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Profundidade { get; set; }
        public Situacao Situacao { get; set; }
        public virtual Lesao Lesao { get; set; }
        public int? CurativoId { get; set; }
        public virtual Curativo? Curativo { get; set; }
        public virtual Profissional? Profissional { get; set; }
    }
}
