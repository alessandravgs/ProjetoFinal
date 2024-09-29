namespace ProjetoFinal.Models
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Login { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }

        public Profissional()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Cpf = string.Empty;
            Login = string.Empty;
            Telefone = string.Empty;
            Senha = string.Empty;
        }
    }
}
