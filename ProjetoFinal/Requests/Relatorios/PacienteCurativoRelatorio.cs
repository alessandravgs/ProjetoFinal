using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests.Relatorios
{
    public class PacienteCurativoRelatorio
    {
        public string NomePaciente { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public List<DetalhesCurativoRelatorio> Curativos { get; set; }

        public PacienteCurativoRelatorio()
        {
            NomePaciente = string.Empty;
            Curativos = [];
        }
    }
}
