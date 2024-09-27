using ProjetoFinal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Lesao
{
    public class LesaoDto
    {
        public int Id { get; set; }
        public PacienteLesaoDto Paciente{ get; set; }
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
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Profundidade { get; set; }
    }

    public class PacienteLesaoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public Sexo Sexo { get; set; }
    }
}
