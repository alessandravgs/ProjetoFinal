using ProjetoFinal.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Requests.Paciente
{
    public record UpdatePacienteRequest(
        [Required] int Id,
        [Required] string Nome,
        [Required] string Cpf,
        [Required] DateTime DataNascimento,
        [Required] Sexo Sexo,
        [Required] string ddd,
        [Required] string Telefone,
        string Email,
        List<int> Alergias,
        List<int> Comorbidades
    );


}
