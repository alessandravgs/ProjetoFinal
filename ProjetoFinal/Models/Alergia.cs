namespace ProjetoFinal.Models
{
    public class Alergia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }

        public Alergia()
        {
            Nome = string.Empty;
            Pacientes = [];
        }
    }
}
