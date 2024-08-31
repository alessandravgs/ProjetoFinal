using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IRepositorioLesao
    {
        Task<bool> SaveLesaoAsync(Lesao lesao);
    }
}
