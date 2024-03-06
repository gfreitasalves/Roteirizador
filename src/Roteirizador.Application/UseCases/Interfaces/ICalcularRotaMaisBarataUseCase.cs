using Roteirizador.Application.Input;
using Roteirizador.Application.Output;

namespace Roteirizador.Application.UseCases.Interfaces
{
    public interface ICalcularRotaMaisBarataUseCase
    {
        Task<ViagemOutput> CalcularAsync(ViagemInput viagem);
    }
}
