using ProjetoFinal.Requests.Lesao;

namespace ProjetoFinal.Interfaces
{
    public interface ILesaoService
    {
        Task RegistrarLesaoAsync(RegisterLesaoRequest lesaoRequest);
    }
}
