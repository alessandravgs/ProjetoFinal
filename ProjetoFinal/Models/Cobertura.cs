namespace ProjetoFinal.Models
{
    public class Cobertura
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public virtual ICollection<Curativo> Curativos { get; set; }

        public Cobertura()
        {
            Nome = string.Empty;
            Descricao = string.Empty;
            Curativos = [];
        }
    }
}
