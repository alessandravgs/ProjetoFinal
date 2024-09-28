using ProjetoFinal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Profissional
{
    public record RegisterProfissionalRequest(
        [Required] string Nome,
        [Required] string Email,
        [Required] string Cpf,
        [Required] string Login,
        [Required] string Telefone,
        [Required] string Senha
    );
}
