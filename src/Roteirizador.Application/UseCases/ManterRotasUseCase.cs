using Roteirizador.Application.Abstractions.Commands;
using Roteirizador.Application.Abstractions.Queries;
using Roteirizador.Application.Input;
using Roteirizador.Application.Output;
using Roteirizador.Application.UseCases.Interfaces;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Application.UseCases
{
    public class ManterRotasUseCase : IManterRotasUseCase
    {
        private readonly IRotaRepository _repository;
        private readonly IRotaQuery _rotaQuery;

        public ManterRotasUseCase(IRotaRepository repository, IRotaQuery rotaQuery)
        {
            _repository = repository;
            _rotaQuery = rotaQuery;
        }

        public async Task<IList<Rota>> SelecionarTodosAsync()
        {
            return await _rotaQuery.SelecionarTodosAsync();
        }

        public async Task<Rota?> SelecionarPorIdAsync(Guid id)
        {
            return await _rotaQuery.SelecionarPorIdAsync(id);
        }        

        public async Task<RotaOutput> InserirAsync(RotaInput rota)
        {
            var entityRota = new Rota(null, rota.Origem, rota.Destino, rota.Valor);

            var result = await _repository.InserirAsync(entityRota);

            return new RotaOutput(result.Id, result.Origem, result.Destino, result.Valor);
        }

        public async Task<RotaOutput> AtualizarAsync(RotaInput rota)
        {
            var entityRota = new Rota(rota.Id, rota.Origem, rota.Destino, rota.Valor);

            var result = await _repository.AtualizarAsync(entityRota);

            return new RotaOutput(result.Id, result.Origem, result.Destino, result.Valor);
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            return await _repository.DeletarAsync(id);
        }        
    }
}
