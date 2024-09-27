using ProjetoFinal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Curativo
{
    public record RegisterCurativoRequest(
       [Required] int PacienteId,
       [Required] int LesaoId,
       [Required] List<int> CoberturasIds,
       string Observacoes,
       string Orientacoes,
       double Altura,
       double Largura,
       double Profundidade
    );
}
