using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests.Lesao
{
    public class LesaoResumoResult
    {
        public int Id { get; set; }
        public string Detalhes { get; set; }
        public string Paciente { get; set; }
        public string PacienteCpf { get; set; }
        public Regiao Regiao { get; set; }
        public LadoRegiao LadoRegiao { get; set; }
        public Situacao Situacao { get; set; }
    }
}
