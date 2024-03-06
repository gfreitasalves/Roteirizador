using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.UseCases
{
    public interface ICalculoRotas 
    {
        IList<IList<Rota>> ObterRotasPossiveis(string origem, string destino, IList<Rota> rotasPossiveis);
    }
}
