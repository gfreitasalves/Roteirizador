using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.Abstractions.Queries
{
    public interface IRotaQuery
    {
        Task<IList<Rota>> SelecionarTodosAsync();
        Task<Rota?> SelecionarPorIdAsync(Guid id);
    }
}
