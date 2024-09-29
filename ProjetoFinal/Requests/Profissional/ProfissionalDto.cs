namespace ProjetoFinal.Requests.Profissional
{
    public class ProfissionalDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Telefone { get; set; }

        public ProfissionalDto()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Cpf = string.Empty;
            Login = string.Empty;
            Telefone = string.Empty;
        }
    }
}
