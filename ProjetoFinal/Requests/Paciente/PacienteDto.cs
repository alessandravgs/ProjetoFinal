using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests.Paciente
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<AlergiaDto> Alergias { get; set; }
        public List<ComorbidadeDto> Comorbidades { get; set; }

        public PacienteDto()
        {
            Nome = string.Empty;
            Cpf = string.Empty;
            Telefone = string.Empty;
            Email = string.Empty;
            Alergias = [];
            Comorbidades = [];
        }
    }

    public class AlergiaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public AlergiaDto()
        {
            Nome = string.Empty;
        }
    }

    public class ComorbidadeDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ComorbidadeDto()
        {
            Nome = string.Empty;
        }
    }

}
