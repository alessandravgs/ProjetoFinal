using Microsoft.IdentityModel.Tokens;
using ProjetoFinal.Helpers;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Requests.Coberturas;
using ProjetoFinal.Requests.Profissional;
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

        public async Task<string> LoginProfissionalAsync(LoginModel login)
        {
            var user = await _repositorio.GetProfissional(login);
            if (user == null)
                throw new UnauthorizedAccessException("Login não autorizado.");

            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]!);
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

        public async Task RegistrarProfissionalAsync(RegisterProfissionalRequest profissionalRequest)
        {
            var profissional = new Profissional()
            {
                Nome = profissionalRequest.Nome,
                Cpf = profissionalRequest.Cpf.GetFormattedCpf(),
                Email = profissionalRequest.Email,
                Login = profissionalRequest.Login.ToLower(),
                Senha = profissionalRequest.Senha,
                Telefone = profissionalRequest.Telefone,
            };

            var salvou = await _repositorio.SaveProfissional(profissional);

            if (!salvou)
                throw new BadHttpRequestException("Erro ao Salvar Profissional.");
        }

        public async Task<ProfissionalDto?> GetProfissionalById(int id)
        {
            return await _repositorio.GetProfissionalByIdAsync(id);
        }

        public async Task<ProfissionalDto> UpdateProfissionalAsync(ProfissionalDto profissionalAtualizar, int id)
        {
            return await _repositorio.UpdateProfissional(profissionalAtualizar, id);
        }

        public async Task<IEnumerable<Curativo>> GetCurativosByProfissionalIdAsync(int id)
        {
            var lista = await _repositorio.GetCurativosByProfissionalAsync(id);
            return lista;
        }
    }
}
