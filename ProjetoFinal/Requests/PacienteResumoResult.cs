using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests
{
    public class PacienteResumoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
