using Roteirizador.Application.Input;
using Roteirizador.Application.Output;

namespace Roteirizador.Application.UseCases.Interfaces
{
    internal interface ICalcularRotaMaisBarataUseCase
    {
        Task<ViagemOutput> Calcular(ViagemInput viagem);
    }
}
