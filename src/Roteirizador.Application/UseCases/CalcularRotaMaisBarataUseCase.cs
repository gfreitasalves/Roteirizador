using Roteirizador.Application.Abstractions.Queries;
using Roteirizador.Application.Input;
using Roteirizador.Application.Output;
using Roteirizador.Application.UseCases.Interfaces;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.UseCases
{
    public class CalcularRotaMaisBarataUseCase : ICalcularRotaMaisBarataUseCase
    {
        private readonly IRotaQuery _obterRotaQuery;
        private readonly ICalculoRotas _calculoRotas;

        public CalcularRotaMaisBarataUseCase(IRotaQuery obterRotaQuery, ICalculoRotas calculoRotas)
        {
            _obterRotaQuery = obterRotaQuery;
            _calculoRotas = calculoRotas;
        }

        public async Task<ViagemOutput> CalcularAsync(ViagemInput viagem)
        {
            IList<Rota> rotas = await _obterRotaQuery.SelecionarTodosAsync();

            var rotasPosiveis = _calculoRotas.ObterRotasPossiveis(viagem.Origem, viagem.Destino, rotas);

            //Obtem a rota de menor valor entre as possíveis
            IList<RotaOutput> rotaMenorValor = rotasPosiveis.OrderBy(x => x.Sum(r => r.Valor)).First()
                .Select(r=>new RotaOutput(r.Id,r.Origem,r.Destino,r.Valor)).ToList();
                        
            return new ViagemOutput(viagem.Origem, viagem.Destino, rotaMenorValor);
        }
    }
}
