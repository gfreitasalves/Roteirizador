using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.UseCases.Interfaces
{
    public interface IObterRotasPossiveisService
    {
        IList<IList<Rota>> ObterRotasPossiveis(string origem, string destino, IList<Rota> rotasPossiveis);
    }
}
