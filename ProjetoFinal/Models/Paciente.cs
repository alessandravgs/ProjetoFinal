namespace ProjetoFinal.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public virtual ICollection<Lesao> Lesoes { get; set; }
        public virtual IEnumerable<Curativo> Curativos {
            get 
            {
                return Lesoes.SelectMany(x => x.Curativos);
            } 
        }
    }
}
