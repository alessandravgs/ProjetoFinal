using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests
{
    public record RegisterCobertura([Required] string Nome, [Required] string Descricao);
}
