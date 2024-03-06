using Roteirizador.Application.Abstractions.Queries;
using Roteirizador.Application.Command;
using Roteirizador.Application.Input;
using Roteirizador.Application.Output;
using Roteirizador.Application.UseCases.Interfaces;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.UseCases
{
    public class CalcularRotaMaisBarataUseCase : ICalcularRotaMaisBarataUseCase
    {
        private readonly IObterRotaQuery _obterRotaQuery;
        private readonly IObterRotasPossiveisService _obterRotasPossiveisService;

        public CalcularRotaMaisBarataUseCase(IObterRotaQuery obterRotaQuery, IObterRotasPossiveisService obterRotasPossiveisService)
        {
            _obterRotaQuery = obterRotaQuery;
            _obterRotasPossiveisService = obterRotasPossiveisService;
        }

        public async Task<ViagemOutput> Calcular(ViagemInput viagem)
        {
            IList<Rota> rotas = await _obterRotaQuery.SelecionarTodosAsync();

            var rotasPosiveis = _obterRotasPossiveisService.ObterRotasPossiveis(viagem.Origem, viagem.Destino, rotas);

            //Obtem a rota de menor valor entre as possíveis
            IList<RotaOutput> rotaMenorValor = rotasPosiveis.OrderBy(x => x.Sum(r => r.Valor)).First()
                .Select(r=>new RotaOutput(r.Id,r.Origem,r.Destino,r.Valor)).ToList();
                        
            return new ViagemOutput(viagem.Origem, viagem.Destino, rotaMenorValor);
        }
    }
}
