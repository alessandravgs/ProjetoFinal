using ProjetoFinal.Models.Enums;
using ProjetoFinal.Requests.Coberturas;

namespace ProjetoFinal.Requests.Curativo
{
    public class CurativoDto
    {
        public int Id { get; set; }
        public PacienteCurativoDto Paciente { get; set; }
        public LesaoCurativoDto Lesao { get; set; }
        public EvolucaoLesaoCurativoDto Evolucao { get; set; }
        public List<CoberturaResumoResult> Coberturas { get; set; }
        public string Orientacoes { get; set; }
        public string Detalhes { get; set; }
        public DateTime Data { get; set; }
        public List<string> Fotos { get; set; }
    }

    public class PacienteCurativoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
    }

    public class LesaoCurativoDto
    {
        public int Id { get; set; }
        public Membro Membro { get; set; }
        public Regiao Regiao { get; set; }
        public LadoRegiao LadoRegiao { get; set; }
        public Situacao Situacao { get; set; }
        public TipoUlcera TipoUlcera { get; set; }
        public bool Cirurgica { get; set; }
        public bool Infectada { get; set; }
        public bool DeiscenciaCirurgica { get; set; }
        public bool Hanseniase { get; set; }
        public bool Miiase { get; set; }
        public bool Amputacao { get; set; }
        public bool Desbridamento { get; set; }
        public bool Traumatica { get; set; }
        public string Detalhes { get; set; }
    }

    public class EvolucaoLesaoCurativoDto
    {
        public double Altura { get; set; }
        public double Largura { get; set; }
        public double Profundidade { get; set; }
    }
}
