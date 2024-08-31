
namespace ProjetoFinal.Requests
{
    public class ProfissionalCurativoRelatorio
    {
        public string NomeProfissional { get; set; }
        public string EmailProfissional { get; set; }
        public string CpfProfissional { get; set; }
        public List<DetalhesCurativoProfissionalRelatorio> Curativos { get; set; }
    }
}
