using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Coberturas
{
    public record RegisterCobertura([Required] string Nome, [Required] string Descricao);
}
