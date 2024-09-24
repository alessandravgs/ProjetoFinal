using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Alergia> Alergias { get; set; }
        public virtual ICollection<Comorbidade> Comorbidades { get; set; }
        public virtual ICollection<Lesao> Lesoes { get; set; } = new List<Lesao>();
    }
}
