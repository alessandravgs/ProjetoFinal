using ProjetoFinal.Requests;

namespace ProjetoFinal.Interfaces
{
    public interface ILesaoService
    {
        Task RegistrarLesaoAsync(RegisterLesaoRequest lesaoRequest);
    }
}
