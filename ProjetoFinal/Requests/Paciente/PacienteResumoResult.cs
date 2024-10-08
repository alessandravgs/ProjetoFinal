﻿using ProjetoFinal.Models.Enums;

namespace ProjetoFinal.Requests.Paciente
{
    public class PacienteResumoResult
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }

        public PacienteResumoResult()
        {
            Nome = string.Empty;
            Cpf = string.Empty;
            Telefone = string.Empty;
        }
    }
}
