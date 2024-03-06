using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.UseCases
{
    public class CalculoRotas : ICalculoRotas
    {
        public IList<IList<Rota>> ObterRotasPossiveis(string origem, string destino, IList<Rota> rotasPossiveis)
        {
            var listRotasCompletas = new List<IList<Rota>>();

            foreach (var rotaPossivel in rotasPossiveis.Where(r => r.Origem == origem))
            {
                var rotasEncadeadas = new List<Rota>();
                rotasEncadeadas.Add(rotaPossivel);

                if (rotaPossivel.Destino == destino)
                {
                    listRotasCompletas.Add(rotasEncadeadas);
                }
                else
                {
                    var origemAtual = rotaPossivel.Destino;
                    var rotasPossiveisAtual = rotasPossiveis.Where(r => r.Id != rotaPossivel.Id).ToList();

                    foreach (var rotaCombinada in ObterRotasPossiveis(origemAtual, destino, rotasPossiveisAtual))
                    {
                        rotasEncadeadas.AddRange(rotaCombinada);
                    }

                    listRotasCompletas.Add(rotasEncadeadas);
                }
            }

            return listRotasCompletas;
        }
    }
}
