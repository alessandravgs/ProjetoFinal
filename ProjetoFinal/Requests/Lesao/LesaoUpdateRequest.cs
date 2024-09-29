using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests.Lesao
{
    public class LesaoUpdateRequest
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Membro Membro { get; set; }
        public Regiao Regiao { get; set; }
        public LadoRegiao LadoRegiao { get; set; }
        public Situacao Situacao { get; set; }
        public bool Cirurgica { get; set; }
        public bool Infectada { get; set; }
        public TipoUlcera TipoUlcera { get; set; }
        public bool DeiscenciaCirurgica { get; set; }
        public bool Hanseniase { get; set; }
        public bool Miiase { get; set; }
        public bool Amputacao { get; set; }
        public bool Desbridamento { get; set; }
        public bool Traumatica { get; set; }
        public string Detalhes { get; set; }
        public int Altura { get; set; }
        public int Largura { get; set; }
        public int Profundidade { get; set; }

        public LesaoUpdateRequest()
        {
            Detalhes = string.Empty;
        }
    }
}
