using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.Abstractions.Commands
{
    public interface IRotaRepository
    {
        Task<Rota> InserirAsync(Rota rota);
        Task<Rota> AtualizarAsync(Rota rota);
        Task<bool> DeletarAsync(Guid id);
    }
}
