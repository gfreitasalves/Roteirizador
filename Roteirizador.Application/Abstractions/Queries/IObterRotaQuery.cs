using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.Abstractions.Queries
{
    public interface IObterRotaQuery
    {
        Task<IList<Rota>> SelecionarTodosAsync();
        Task<Rota?> SelecionarPorIdAsync(Guid id);
    }
}
