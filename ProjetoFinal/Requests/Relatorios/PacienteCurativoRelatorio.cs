using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests.Relatorios
{
    public class PacienteCurativoRelatorio
    {
        public string NomePaciente { get; set; }
        public string Cpf { get; set; }
        public string Contato { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<DetalhesCurativoRelatorio> Curativos { get; set; }

        public PacienteCurativoRelatorio()
        {
            NomePaciente = string.Empty;
            Curativos = [];
            Contato = string.Empty;
            Cpf = string.Empty;
        }
    }
}
