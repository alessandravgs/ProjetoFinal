using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface ICurativoService
    {
        Task RegistrarCurativoAsync(Curativo curativo);
        Task<Curativo?> GetCurativoAsync(string parametro);
    }
}
