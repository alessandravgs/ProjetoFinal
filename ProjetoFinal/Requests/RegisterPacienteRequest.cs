using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests
{
    public record RegisterPacienteRequest([Required] string Nome, [Required] string Cpf, [Required] DateTime DataNascimento);

}
