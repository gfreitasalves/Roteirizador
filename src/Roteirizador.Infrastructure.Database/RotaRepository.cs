using Roteirizador.Application.Abstractions.Commands;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Infrastructure.Database
{
    public class RotaRepository : IRotaRepository
    {
        private readonly RoteirizadorDbContext _roteirizadorDbContext;

        public RotaRepository(RoteirizadorDbContext roteirizadorDbContext)
        {
            _roteirizadorDbContext = roteirizadorDbContext;
        }

        public async Task<Rota> AtualizarAsync(Rota rota)
        {
            var rotaBd = _roteirizadorDbContext.Rotas.FirstOrDefault(r => r.Id == rota.Id);

            if (rotaBd == null) throw new InvalidOperationException();

            rotaBd.Origem = rota.Origem;
            rotaBd.Destino = rota.Destino;
            rotaBd.Valor = rota.Valor;

            _roteirizadorDbContext.Rotas.Update(rotaBd);

            await _roteirizadorDbContext.SaveChangesAsync();

            return rotaBd;
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var rota = _roteirizadorDbContext.Rotas.FirstOrDefault(r => r.Id == id);

            if (rota == null) return false;

            _roteirizadorDbContext.Rotas.Remove(rota);

            await _roteirizadorDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Rota> InserirAsync(Rota rota)
        {
            _roteirizadorDbContext.Rotas.Add(rota);

            await _roteirizadorDbContext.SaveChangesAsync();

            return rota;
        }
    }
}
