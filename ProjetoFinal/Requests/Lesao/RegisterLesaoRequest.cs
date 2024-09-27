using ProjetoFinal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Lesao
{
    public record RegisterLesaoRequest(
        [Required] int PacienteId,
        [Required] Membro Membro,
        [Required] Regiao Regiao,
        [Required] LadoRegiao LadoRegiao,
        [Required] Situacao Situacao,
        bool Cirurgica,
        bool Infectada,
        TipoUlcera TipoUlcera,
        bool DeiscenciaCirurgica,
        bool Hanseniase,
        bool Miiase,
        bool Amputacao,
        bool Desbridamento,
        bool Traumatica,
        string Detalhes,
        double Altura,
        double Largura,
        double Profundidade
        );

}
