namespace ProjetoFinal.Models
{
    public class Curativo
    {
        public int Id { get; set; }
        public virtual Profissional Profissional { get; set; }
        public virtual Lesao Lesao { get; set; }
        public virtual EvolucaoLesao EvolucaoLesao { get; set; }
        public string Observacoes { get; set; }
        public string Orientacoes { get; set; }
        public DateTime Data { get; set; }
        public virtual ICollection<Cobertura> Coberturas { get; set; }
        public virtual ICollection<ImagemCurativo> Imagens { get; set; }
    }
}
