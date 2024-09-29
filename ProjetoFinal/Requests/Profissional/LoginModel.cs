namespace ProjetoFinal.Requests.Profissional
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginModel()
        {
            Email = string.Empty;
            Senha = string.Empty;
        }
    }
}
