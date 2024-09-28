using ProjetoFinal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Curativo
{
    public record UpdateCurativoRequest(
       [Required] int Id,
       [Required] int PacienteId,
       [Required] int LesaoId,
       [Required] List<int> CoberturasIds,
       string Observacoes,
       string Orientacoes,
       [Required] double Altura,
       [Required] double Largura,
       [Required] double Profundidade,
       [Required] Situacao SituacaoLesao
    );
}
