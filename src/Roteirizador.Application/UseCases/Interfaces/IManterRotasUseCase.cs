using Roteirizador.Application.Input;
using Roteirizador.Application.Output;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.UseCases.Interfaces
{
    public interface IManterRotasUseCase
    {
        Task<IList<Rota>> SelecionarTodosAsync();
        Task<Rota?> SelecionarPorIdAsync(Guid id);
        Task<RotaOutput> InserirAsync(RotaInput rota);
        Task<RotaOutput> AtualizarAsync(RotaInput rota);
        Task<bool> DeletarAsync(Guid id);
    }
}
