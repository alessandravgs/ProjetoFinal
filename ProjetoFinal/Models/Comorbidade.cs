namespace ProjetoFinal.Models
{
    public class Comorbidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }

        public Comorbidade()
        {
            Nome = string.Empty;
            Pacientes = [];
        }
    }
}
