namespace ProjetoFinal.Models
{
    public class Lesao
    {
        public int Id { get; set; }
        //Tipo Membro
        public string Membro { get; set; }
        //Tipo Regiao
        public string Regiao { get; set; }
        //Tipo Situacao
        public string Situacao { get; set; }
        public bool Cirurgica { get; set; }
        public bool Infectada { get; set; }
        //Tipo Ulcera
        public string UlceraVenosa { get; set; }
        public bool DeiscenciaCirurgica { get; set; }
        public bool Hanseniase { get; set; }
        public bool Miiase { get; set; }
        public bool Amputacao { get; set; }
        public bool Desbridamento { get; set; }
        public bool Traumatica { get; set; }
        public string Detalhes { get; set; }
        public virtual Paciente Paciente { get; set; }
        public virtual ICollection<Curativo> Curativos { get; set; }
    }
}
