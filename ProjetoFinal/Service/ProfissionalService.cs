using Microsoft.IdentityModel.Tokens;
using ProjetoFinal.Controllers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjetoFinal.Service
{
    public class ProfissionalService: IProfissionalService
    {
        private readonly IRepositorioProfissional _repositorio;
        private readonly IConfiguration _configuration;

        public ProfissionalService(IRepositorioProfissional repositorioProfissional, IConfiguration configuration) 
        { 
            _repositorio = repositorioProfissional;
            _configuration = configuration;
        }

        public async Task<string> LoginProfissional(LoginModel login)
        {
            var user = await _repositorio.GetProfissional(login);
            if (user == null)
                throw new UnauthorizedAccessException("Login não autorizado.");

            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()) // Inclua o ID como um claim
                }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
                Audience = audience,
                Issuer = issuer
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task RegistrarProfissional(Profissional profissional)
        {
            var salvou = await _repositorio.SaveProfissional(profissional);

            if (!salvou)
                throw new BadHttpRequestException("Erro ao Salvar Profissional.");
        }

        public async Task<IEnumerable<Curativo>> GetCurativosByProfissionalId(int id)
        {
            var lista = await _repositorio.GetCurativosByProfissionalAsync(id);
            return lista;
        }

        public async Task<IEnumerable<Paciente>> GetPacientesByProfissional(int id)
        {
            var lista = await _repositorio.GetPacientesByProfissional(id);
            return lista;
        }
    }
}
