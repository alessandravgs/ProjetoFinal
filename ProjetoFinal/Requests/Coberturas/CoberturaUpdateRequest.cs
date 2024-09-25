using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Coberturas
{
    public record CoberturaUpdateRequest([Required] int Id, [Required] string Nome, [Required] string Descricao);

}
