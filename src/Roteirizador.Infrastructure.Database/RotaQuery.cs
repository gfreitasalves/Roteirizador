using Microsoft.EntityFrameworkCore;
using Roteirizador.Application.Abstractions.Queries;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Infrastructure.Database
{
    public class RotaQuery : IRotaQuery
    {
        private readonly RoteirizadorDbContext _roteirizadorDbContext;

        public RotaQuery(RoteirizadorDbContext roteirizadorDbContext)
        {
            _roteirizadorDbContext = roteirizadorDbContext;
        }

        public async Task<Rota?> SelecionarPorIdAsync(Guid id)
        {
            return await _roteirizadorDbContext.Rotas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Rota>> SelecionarTodosAsync()
        {
            return await _roteirizadorDbContext.Rotas.ToListAsync();
        }
    }
}
