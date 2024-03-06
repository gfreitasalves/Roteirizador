using Microsoft.EntityFrameworkCore;
using Roteirizador.Domain.Entities;

namespace Roteirizador.Infrastructure.Database
{
    public class RoteirizadorDbContext : DbContext
    {
        public RoteirizadorDbContext(DbContextOptions<RoteirizadorDbContext> options)
          : base(options)
        {
            AdicionarDadosDeTeste();
        }

        public DbSet<Rota> Rotas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rota>().HasKey(l => l.Id);

            base.OnModelCreating(modelBuilder);
        }

        public void AdicionarDadosDeTeste()
        {
            if (!Rotas.Any())
            {
                var rotas = new List<Rota>()
                {
                    new Rota(null,"GRU","BRC",10),
                    new Rota(null,"BRC","SCL",5),
                    new Rota(null,"GRU","CDG",75),
                    new Rota(null,"GRU","SCL",20),
                    new Rota(null,"GRU","ORL",56),
                    new Rota(null,"ORL","CDG",5),
                    new Rota(null,"SCL","ORL",20)
                };

                Rotas.AddRange(rotas);

                SaveChanges();
            }
        }
    }
}