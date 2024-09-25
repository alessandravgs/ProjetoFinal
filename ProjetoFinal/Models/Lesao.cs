using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Models
{
    public class Lesao
    {
        public int Id { get; set; }
        public Membro Membro { get; set; }
        public Regiao Regiao { get; set; }
        public LadoRegiao LadoRegiao { get; set; }
        public Situacao Situacao { get; set; }
        public bool Cirurgica { get; set; }
        public bool Infectada { get; set; }
        public TipoUlcera UlceraVenosa { get; set; }
        public bool DeiscenciaCirurgica { get; set; }
        public bool Hanseniase { get; set; }
        public bool Miiase { get; set; }
        public bool Amputacao { get; set; }
        public bool Desbridamento { get; set; }
        public bool Traumatica { get; set; }
        public string Detalhes { get; set; }
        public int UltimaEvolucaoId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<Curativo> Curativos { get; set; }
        public virtual ICollection<EvolucaoLesao> Evolucoes { get; set; }
    }
}
