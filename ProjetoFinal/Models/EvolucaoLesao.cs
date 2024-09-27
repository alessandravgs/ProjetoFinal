using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Models
{
    public class EvolucaoLesao
    {
        public int Id { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Profundidade { get; set; }
        public Situacao Situacao { get; set; }
        public virtual Lesao Lesao { get; set; }
        public int? CurativoId { get; set; }
        public virtual Curativo? Curativo { get; set; }
        public virtual Profissional? Profissional { get; set; }
    }
}
